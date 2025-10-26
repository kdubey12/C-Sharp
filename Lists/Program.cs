using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Common;

static int ManualSum(List<int> nums)
{
    int total = 0;

    foreach (int i in nums) total += i;

    return total;
}

Debug.Assert(ManualSum([2, 3, 4, 5]) == 14);

static int ManualMax(List<int> nums)
{
    int max = 0;

    foreach (int i in nums) if (i > max) max = i;

    return max;
}

Debug.Assert(ManualMax([2, 3, 4, 5]) == 5);

static int ManualMin(List<int> nums)
{
    int min = int.MaxValue;

    foreach (int i in nums) if (i < min) min = i;

    return min;
}

Debug.Assert(ManualMin([2, 3, 4, 5]) == 2);

static List<int> ManualNegatives(List<int> nums)
{
    List<int> negative_nums = new List<int>();

    foreach (int i in nums) if (i < 0) negative_nums.Add(i);

    return negative_nums;
}

Debug.Assert(ManualNegatives([2, 3, -4, -5]).SequenceEqual([-4, -5]));

static bool CheckListEquality(List<int> a, List<int> b)
{
    if (a.Count != b.Count) return false;

    for (int i = 0; i < a.Count; i++) if (a[i] != b[i]) return false;

    return true;
}

Debug.Assert(CheckListEquality([2, 3, 4, 5], [2, 3, 4, 5]) == true);

static bool CheckListEqualityNoDupes(List<int> a, List<int> b)
{
    HashSet<int> h_a = a.ToHashSet();
    HashSet<int> h_b = b.ToHashSet();

    return h_a.SequenceEqual(h_b);
}

Debug.Assert(CheckListEqualityNoDupes([2, 2, 3, 4, 5, 6, 7, 7, 7], [2, 3, 4, 5, 6, 7]) == true);

static bool NaiveSearch(int n, List<int> sorted)
{
    foreach (int i in sorted) if (i == n) return true;

    return false;
}

Debug.Assert(NaiveSearch(7, [2, 3, 4, 7, 11, 13, 15]) == true);

static bool BinarySearch(int n, List<int> sorted)
{
    if (n < sorted[0] || n > sorted[sorted.Count - 1]) return false;
    int m_index = (sorted.Count - 1) / 2;
    int middle = sorted[m_index];

    if (middle == n) return true;

    if (n > middle) return BinarySearch(n, sorted.Skip(m_index+1).ToList());
    else return BinarySearch(n, sorted.Take(m_index).ToList());
}

Debug.Assert(BinarySearch(7, [2, 3, 4, 6, 6, 7, 8, 10, 12]) == true);

static List<int> GetDuplicates(List<int> nums)
{
    return nums.Where(k => nums.Where(c => c == k).Count() > 1).ToHashSet().ToList();
}

Debug.Assert(GetDuplicates([2, 2, 3, 4, 5, 5, 6, 6, 6, 6, 6, 7]).SequenceEqual([2, 5, 6]));

static bool IsSubset(List<int> a, List<int> b)
{
    HashSet<int> set_a = a.ToHashSet();
    HashSet<int> set_b = b.ToHashSet();

    if (set_a == set_b || set_a.Intersect(set_b).ToList().Count != 0) return true;

    return false;
}

Debug.Assert(IsSubset([2, 3, 4, 5, 6, 7], [3, 6]) == true);