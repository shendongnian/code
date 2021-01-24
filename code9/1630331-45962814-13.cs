    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main()
            {
                int[] values = {319, 4, 90, 50, 20, 99, 500, 95, 900};
                foreach (var combination in FindMatches(values, 300, 5, 10))
                {
                    Console.WriteLine(string.Join(", ", combination));
                }
            }
            static IEnumerable<List<int>> FindMatches(IList<int> values, int target, int toleranceLow, int toleranceHigh)
            {
                int minDiff = (target * toleranceLow)  / 100;
                int maxDiff = (target * toleranceHigh) / 100;
                foreach (var sum in SummedCombinations(values))
                {
                    int diff = Math.Abs(sum.Sum - target);
                    if (minDiff <= diff && diff <= maxDiff)
                        yield return sum.Values;
                }
            }
            static IEnumerable<(int Sum, List<int> Values)> SummedCombinations(IList<int> values)
            {
                return 
                    Combinations(values)
                    .Select(comb => comb.ToList())
                    .Select(comb => (comb.Sum(), comb));
            }
            public static IEnumerable<IEnumerable<T>> Combinations<T>(IList<T> items)
            {
                return Combinations(items.Count).Select(comb => comb.Select(index => items[index]));
            }
            public static IEnumerable<IEnumerable<int>> Combinations(int n)
            {
                long m = 1 << n;
                for (long i = 1; i < m; ++i)
                    yield return bitIndices((uint)i);
            }
            static IEnumerable<int> bitIndices(uint n)
            {
                uint mask = 1;
                for (int bit = 0; bit < 32; ++bit, mask <<= 1)
                    if ((n & mask) != 0)
                        yield return bit;
            }
        }
    }
