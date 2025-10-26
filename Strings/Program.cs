using System.Diagnostics;
using System.Text;
using Common;

static List<string> Wave(string s)
{
    List<string> output = new List<string>() { string.Concat(char.ToUpper(s[0]), s.Substring(1)) };

    for (int i = 1; i < s.Length; i++)
    {
        if (s[i] == ' ') continue;
        output.Add(string.Concat(s.Substring(0, i), char.ToUpper(s[i]), s.Substring(i + 1)));
    }

    return output;
}

Debug.Assert(Wave("hello").SequenceEqual(["Hello", "hEllo", "heLlo", "helLo", "hellO"]));

static List<int> ToCode(string s)
{
    List<int> output = [.. s];

    return output;
}

Debug.Assert(ToCode("Hello").SequenceEqual([72, 101, 108, 108, 111]));

static byte[] ToByteArray(string s)
{
    byte[] ns = Encoding.Default.GetBytes(s);

    return ns;
}

Debug.Assert(ToByteArray("Hello").ToList().SequenceEqual([(byte)72, (byte)101, (byte)108, (byte)108, (byte)111]));

static string CodeToString(List<int> n)
{
    StringBuilder sb = new StringBuilder();

    foreach (int i in n) sb.Append((char)i);

    return sb.ToString();
}

Debug.Assert(CodeToString([72, 101, 108, 108, 111]) == "Hello");

static string ByteToString(byte[] b)
{
    return Encoding.UTF8.GetString(b);
}

Debug.Assert(ByteToString([206, 188, 206, 174, 206, 187, 206, 191]) == "μήλο");

static int Anagram(string s, List<string> vals)
{
    int total = 0;

    foreach (string i in vals) if (i.Order().SequenceEqual(s.Order())) total += 1;

    return total;
}

Debug.Assert(Anagram("star", ["rats", "arts", "arc"]) == 2);

static string VarNamer()
{
    Console.WriteLine("Enter variable name.");
    string? input = Console.ReadLine();

    if (input == null) return "";

    string[] parts = input.Split(' ');

    Console.WriteLine("Pick naming convention: 1 - camelCase, 2 - Pascalcase, 3 - snake_case");
    int n = IOTool.InputInt();

    StringBuilder sb = new StringBuilder();
    string f;

    switch (n)
    {
        case 1:
            f = string.Concat(parts[0][0].ToString().ToLower(), parts[0].Substring(1).ToLower());
            sb.Append(f);

            for (int i = 1; i < parts.Length; i++)
            {
                string s = parts[i];
                sb.Append(string.Concat(s[0].ToString().ToUpper(), s.Substring(1)));
            }
            break;
        case 2:
            f = string.Concat(parts[0][0].ToString().ToUpper(), parts[0].Substring(1).ToLower());
            sb.Append(f);

            for (int i = 1; i < parts.Length; i++)
            {
                string s = parts[i];
                sb.Append(string.Concat(s[0].ToString().ToUpper(), s.Substring(1).ToLower()));
            }
            break;
        case 3:
            f = parts[0].ToLower();
            sb.Append(f);

            for (int i = 1; i < parts.Length; i++)
            {
                string s = string.Concat("_", parts[i].ToLower());
                sb.Append(s);
            }
            break;
        default:
            Console.WriteLine("Invalid choice.");
            break;
    }

    return sb.ToString();
}