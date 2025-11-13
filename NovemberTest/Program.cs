using System.Diagnostics;

/* Fix me */
List<string> listOfStrings = new List<string>() { "13", "Candy", "Mike Myers", "True", "#FF5F1F", "1978" };

static int NextOnAThursday()
{
    int currentYear = DateTime.Today.Year;
    bool found = false;

    while (!found)
    {
        currentYear += 1;

        int currentDayOfWeek = (int) new DateTime(currentYear, 11, 06).DayOfWeek;
        if (currentDayOfWeek == 4) found = true;
    }

    return currentYear;
}

static bool ComputeSweets(List<int> pileSizes, int numHours, int sweetsPerHour)
{
    while (numHours != 0)
    {
        pileSizes = pileSizes.OrderDescending().ToList();

        if (pileSizes[0] < sweetsPerHour) pileSizes[0] = 0;
        else pileSizes[0] -= sweetsPerHour;

        numHours--;
    }

    if (pileSizes.Sum() != 0) return false; // If there are sweets left over, this SPH is invalid.
    return true;
}

static int EatingSweets(List<int> pileSizes, int numHours)
{
    int minSweetsPerHour = 1;

    while (!ComputeSweets(pileSizes, numHours, minSweetsPerHour)) minSweetsPerHour += 1;

    return minSweetsPerHour;
}

static int CuttingChocolate(int numberOfCuts)
{
    int max = 0;

    for (int x = 1; x < numberOfCuts; x++) 
        if (x * (numberOfCuts - x) > max) 
            max = x * (numberOfCuts - x);

    return max;
}

static bool ValidatePassword(string candidate)
{
    if (candidate.Length < 8 || candidate.Length > 32
        || candidate.ToLowerInvariant() == candidate || candidate.ToUpperInvariant() == candidate
        || !candidate.Where(char.IsDigit).Any()
        || candidate.ToHashSet().Count != candidate.Length) return false;
    
    List<int> asciiCode = candidate.Select(k => (int)k).ToList(); // Check after other conditions to improve performance.
    if (asciiCode.Sum() % 11 != 0) return false;

    return true;
}

Debug.Assert(NextOnAThursday() == 2031);

// Note the exclamation marks showing not, so False 
Debug.Assert(!ValidatePassword("ABCdef")); // too short
Debug.Assert(!ValidatePassword("ABCABC12!")); // duplicates, doesn't divide by 11
Debug.Assert(!ValidatePassword("ABCabcde!")); // no digit 
Debug.Assert(!ValidatePassword("ABCdef12!")); // doesn't divide by 11 
Debug.Assert(!ValidatePassword("AAAAAAAAAA12aaaaa")); // duplicates only
Debug.Assert(!ValidatePassword("ABCdef12!")); // doesn't divide by 11 
Debug.Assert(ValidatePassword("ABCdef12&")); // should succeed

Debug.Assert(CuttingChocolate(5) == 6);
Debug.Assert(CuttingChocolate(6) == 9);
Debug.Assert(CuttingChocolate(7) == 12);
Debug.Assert(CuttingChocolate(8) == 16);

List<int> pileSizes = new List<int> { 4, 9, 11, 17 };
int numHours = 8;

Debug.Assert(EatingSweets(pileSizes, numHours) == 6);