using System.Diagnostics;
using System.Text;
using Common;


static int GetCardScore(List<int> cards)
{
    List<List<int>> combinations = IOTool.GetAllCombinations(cards).Select(k => k.ToList()).ToList();
    int score = 0;

    foreach (List<int> subset in combinations)
    {
        if (subset.Sum() == 15) score += 1;
        if (subset.Count == 2 && subset.Distinct().Count() == 1) score += 1;
    }

    return score;
}

Debug.Assert(GetCardScore([3, 3, 3, 2, 10]) == 6);
Debug.Assert(GetCardScore([3, 4, 7, 9, 10]) == 0);
Debug.Assert(GetCardScore([7, 9, 2, 2, 10]) == 1);
Debug.Assert(GetCardScore([2, 7, 9, 10, 2]) == 1);
Debug.Assert(GetCardScore([2, 2, 3, 3, 4]) == 2);
Debug.Assert(GetCardScore([7, 6, 6, 6, 10]) == 3);
Debug.Assert(GetCardScore([1, 6, 2, 4, 9]) == 2);
Debug.Assert(GetCardScore([1, 8, 2, 3, 9]) == 1);
Debug.Assert(GetCardScore([2, 2, 7, 8, 2]) == 4);
Debug.Assert(GetCardScore([5, 5, 10, 5, 5]) == 14);


static void Q1()
{
    List<int> cards = IOTool.InputIntList();

    Console.WriteLine(GetCardScore(cards));
}

//Q1();

static string Rewrite(string inp, int limit)
{
    StringBuilder sb = new StringBuilder();

    foreach (char i in inp)
    {
        if (i == 'A') sb.Append('B');
        if (i == 'B') sb.Append("AB");
        if (i == 'C') sb.Append("CD");
        if (i == 'D') sb.Append("DC");
        if (i == 'E') sb.Append("EE");

        if (sb.Length >= limit) break;
    }

    if (sb.Length > limit) sb.Length = limit;
    return sb.ToString();
}

static List<int> ProcessString(string inp, int steps, int position)
{
    for (int i = 0; i < steps; i++) inp = Rewrite(inp, position);
    List<char> vals = "ABCDE".ToList();
    List<int> result = [];

    foreach (char i in vals) result.Add(inp.Take(position).Where(k => k == i).Count());

    return result;
}

Debug.Assert(ProcessString("DEC", 2, 10).SequenceEqual([0, 0, 3, 3, 4]));
Debug.Assert(ProcessString("BDA", 1, 5).SequenceEqual([1, 2, 1, 1, 0]));
Debug.Assert(ProcessString("ABA", 5, 29).SequenceEqual([11, 18, 0, 0, 0]));
Debug.Assert(ProcessString("EEE", 10, 3072).SequenceEqual([0, 0, 0, 0, 3072]));
Debug.Assert(ProcessString("CDD", 12, 12001).SequenceEqual([0, 0, 6000, 6001, 0]));
Debug.Assert(ProcessString("CDC", 12, 12001).SequenceEqual([0, 0, 6001, 6000, 0]));
Debug.Assert(ProcessString("ACE", 15, 987).SequenceEqual([377, 610, 0, 0, 0]));
Debug.Assert(ProcessString("ACE", 15, 17371).SequenceEqual([377, 610, 8192, 8192, 0]));
Debug.Assert(ProcessString("ACE", 15, 66523).SequenceEqual([377, 610, 16384, 16384, 32768]));
Debug.Assert(ProcessString("DAE", 29, 1).SequenceEqual([0, 0, 0, 1, 0]));
Debug.Assert(ProcessString("EEE", 29, 1000000000).SequenceEqual([0, 0, 0, 0, 1000000000]));
Debug.Assert(ProcessString("BAB", 29, 1664080).SequenceEqual([635622, 1028458, 0, 0, 0]));
Debug.Assert(ProcessString("BED", 29, 1000000000).SequenceEqual([514229, 832040, 230891410, 230891409, 536870912]));

static void Q3()
{
    string? inp = Console.ReadLine();
    if (inp == null) return;

    List<int> nums = IOTool.InputIntList();
    if (nums.Count != 2) return;

    IOTool.PrintList(ProcessString(inp, nums[0], nums[1]));
}

//Q3();