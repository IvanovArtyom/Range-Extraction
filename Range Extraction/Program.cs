using System.Collections.Generic;
using System.Linq;

public class RangeExtraction
{
    public static void Main()
    {
        // Test
        var t = Extract(new[] { -10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20 });
        // ...should return "-10--8,-6,-3-1,3-5,7-11,14,15,17-20"
    }

    public static string Extract(int[] args)
    {
        List<string> result= new();

        for (int i = 0; i < args.Length; i++)
        {
            int j = i + 1;

            while (j < args.Length && args[j - 1] == args[j] - 1) ++j;

            if (j - i >= 3)
                result.Add($"{args[i]}-{args[j - 1]}");

            else if (j - i == 2)
                result.AddRange(args[i..j].Select(x => x.ToString()));

            else result.Add(args[i].ToString());

            i = j - 1;
        }

        return string.Join(",", result);
    }
}