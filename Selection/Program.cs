using System.Diagnostics;
using Common;

static bool CheckEquality(int a, int b)
{
    return a == b;
}

Debug.Assert(CheckEquality(3, 3) == true);

static bool IsEven(int n)
{
    return n % 2 == 0;
}

Debug.Assert(IsEven(29) == false);

static bool IsLeapYear(int year)
{
    if (year % 400 == 0) return true;
    if (year % 100 == 0) return false;
    if (year % 4 == 0) return true;

    return false;
}

Debug.Assert(IsLeapYear(2028) == true);

static void FizzBuzzReturn(int n)
{
    string output;

    if (n % 3 == 0 && n % 5 == 0) output = "FizzBuzz";
    else if (n % 3 == 0) output = "Fizz";
    else if (n % 5 == 0) output = "Buzz";
    else output = n.ToString();

    Console.WriteLine(output);
}

static int NumFactors(int n)
{
    int highest_comparison = Convert.ToInt32(Math.Floor(Math.Sqrt(n)));
    int total = 0;


    for (int i = 1; i <= highest_comparison; i++)
    {
        if (i * i == n) total += 1;
        else if (n % i == 0) total += 2;
    }

    return total;
}

Debug.Assert(NumFactors(24) == 8);

static bool IsVowel(char s)
{
    return "aeiou".Contains(char.ToLower(s));
}

Debug.Assert(IsVowel('a') == true);

static int GetRequiredBlocks(double sizeInKiB)
{
    return Convert.ToInt32(Math.Ceiling(sizeInKiB * 2));
}

Debug.Assert(GetRequiredBlocks(2048) == 4096);

static void PocketMoney()
{
    double weekly_allowance = IOTool.InputDouble();
    double percentage = IOTool.InputDouble();

    Console.WriteLine($"Weekly Saving: {Math.Round(weekly_allowance * percentage, 2)}\nYearly Saving: {Math.Round(weekly_allowance * percentage * 52, 2)}");
}

static int FindGreatest()
{
    List<int> nums = IOTool.InputIntList();

    return nums.Max();
}

static int GetQuadrant(int x, int y)
{
    if (x < 0 && y >= 0) return 2;
    if (x < 0 && y < 0) return 3;
    if (x >= 0 && y < 0) return 4;

    return 1;
}

Debug.Assert(GetQuadrant(-2, 5) == 2);

static bool IsPointInsideCircle(int x, int y, int r, int cx = 0, int cy = 0)
{
    double point_dist = Math.Sqrt(Math.Pow(Math.Abs(x - cx), 2) + Math.Pow(Math.Abs(y - cy), 2));

    if (point_dist <= r) return true;

    return false;
}

Debug.Assert(IsPointInsideCircle(1, 2, 10, 2, 2) == true);

static void GradeScore()
{
    List<int> scores = IOTool.InputIntList();

    double average_score = scores.Average();
    string grade;

    if (average_score >= 90) grade = "A*";
    else if (average_score >= 80) grade = "A";
    else if (average_score >= 70) grade = "B";
    else if (average_score >= 50) grade = "C";
    else grade = "F";

    Console.WriteLine(grade);
}

static void AgeVerification()
{
    Console.WriteLine("Enter your date of birth in form (DD/MM/YYYY).");
    string? inp = Console.ReadLine();

    if (inp == null) return;

    string[] parts = inp.Split('/');

    if (parts.Length != 3 ||
        !int.TryParse(parts[0], out int day) ||
        !int.TryParse(parts[1], out int month) ||
        !int.TryParse(parts[2], out int year))
    {
        Console.WriteLine("Error - invalid format.");
        return;
    }
    DateTime birth_date = new DateTime(year, month, day);
    DateTime today = DateTime.Now;

    int age = today.Year - birth_date.Year;

    if (birth_date.Date > today.AddYears(-age)) age--;

    if (age >= 18) Console.WriteLine("You are eligible to be paid.");
    else if (age >= 16) Console.WriteLine("You can volunteer!");
    else if (age >= 13) Console.WriteLine("You can go to the activity camp.");
    else Console.WriteLine("You are not eligible for anything.");
}

static void TriangleClassification()
{
    List<int> sides = IOTool.InputIntList();

    if (sides.Count != 3) return;

    if (sides[0] == sides[1] && sides[1] == sides[2]) Console.WriteLine("Equliateral.");
    else if (sides[0] == sides[1] || sides[1] == sides[2] || sides[0] == sides[2]) Console.WriteLine("Isoceles");
    else Console.WriteLine("Scalene");
}