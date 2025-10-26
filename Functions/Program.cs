using System.Diagnostics;
using Common;

static bool IsPrime(int n)
{
    if (n < 2) return false;
    if (n == 2 || n == 3) return true;

    int highest_comparison = Convert.ToInt32(Math.Floor(Math.Sqrt(n)));

    for (int i = 2; i <= highest_comparison; i++) if (n % i == 0) return false;

    return true;
}

Debug.Assert(IsPrime(13) == true);
Debug.Assert(IsPrime(27) == false);

static int CountSpaces(string s)
{
    return s.Where(k => k == ' ').Count();
}

Debug.Assert(CountSpaces("This sentence has 4 spaces.") == 4);

static void Swap(ref int a, ref int b)
{
    (b, a) = (a, b);
}

static string Translate(int n, int nbase)
{
    return Convert.ToString(n, nbase);
}