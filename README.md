## Description:

A format for expressing an ordered list of integers is to use a comma separated list of either

- individual integers
- or a range of integers denoted by the starting integer separated from the end integer in the range by a dash, '-'.
The range includes all integers in the interval including both endpoints. It is not considered a range unless it spans at least 3 numbers. For example "12,13,15-17"

Complete the solution so that it takes a list of integers in increasing order and returns a correctly formatted string in the range format.

**Example:**
```C#
solution([-10, -9, -8, -6, -3, -2, -1, 0, 1, 3, 4, 5, 7, 8, 9, 10, 11, 14, 15, 17, 18, 19, 20]);
// returns "-10--8,-6,-3-1,3-5,7-11,14,15,17-20"
```
*Courtesy of rosettacode.org*
### My solution
``` C#
using System.Collections.Generic;
using System.Linq;

public class RangeExtraction
{
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
```
