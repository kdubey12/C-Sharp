using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Reflection.Metadata.Ecma335;

namespace Common;

public class IOTool
{
    public static int InputInt()
    {
        string? input = Console.ReadLine();

        if (!int.TryParse(input, out int result)) throw new InvalidCastException("Input was not an integer.");

        return result;
    }

    public static double InputDouble()
    {
        string? input = Console.ReadLine();

        if (!double.TryParse(input, out double result)) throw new InvalidCastException("Input was not a double.");

        return result;
    }

    public static List<int> InputIntList()
    {
        string? input = Console.ReadLine() ?? throw new ArgumentNullException("Input was null.");
        string[] parts = input.Split(' ');

        List<int> nums = new List<int>();

        foreach (string i in parts) nums.Add(Convert.ToInt32(i));

        return nums;
    }

    public static void PrintList<T>(List<T> arr)
    {
        Console.WriteLine($"[ {string.Join(", ", arr)} ]");
    }
}
