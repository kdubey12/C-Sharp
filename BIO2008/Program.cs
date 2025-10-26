using System.Diagnostics;
using System.Security.Principal;
using Common;

static bool IsPrime(int n)
{
    if (n < 2) return false;
    if (n == 2 || n == 3) return true;

    int highest_comparison = Convert.ToInt32(Math.Floor(Math.Sqrt(n)));

    for (int i = 2; i <= highest_comparison; i++) if (n % i == 0) return false;

    return true;
}

static List<int> GeneratePrimes(int limit)
{
    List<int> result = [];

    for (int i = 2; i <= limit; i++) if (IsPrime(i)) result.Add(i);

    return result;
}

static int GetTotalPrimePairs(int target)
{
    HashSet<int> values = [];

    List<int> primes = GeneratePrimes(target);

    for (int i = 0; i < primes.Count; i++)
        for (int j = 0; j < primes.Count; j++) if (primes[i] + primes[j] == target) values.Add(primes[i]);

    return Convert.ToInt32(Math.Ceiling(values.Count / 2.0));
}

Debug.Assert(GetTotalPrimePairs(22) == 3);
Debug.Assert(GetTotalPrimePairs(4) == 1);
Debug.Assert(GetTotalPrimePairs(8) == 1);
Debug.Assert(GetTotalPrimePairs(62) == 3);
Debug.Assert(GetTotalPrimePairs(114) == 10);
Debug.Assert(GetTotalPrimePairs(346) == 9);
Debug.Assert(GetTotalPrimePairs(1000) == 28);
Debug.Assert(GetTotalPrimePairs(2326) == 35);
Debug.Assert(GetTotalPrimePairs(5000) == 76);
Debug.Assert(GetTotalPrimePairs(9240) == 329);



static void Q1()
{
    int target = IOTool.InputInt();

    Console.WriteLine(GetTotalPrimePairs(target));
    /*
    int total = 0;
    for (int i = 5; i < 50; i += 2) if (GetTotalPrimePairs(i) == 0) total += 1;

    Console.WriteLine(total);
    */
}

// (b) 3, 43 | 5, 41 | 17, 29 | 23, 23
// (c) 9

//Q1();

