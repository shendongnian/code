    using System;
    using System.Collections.Generic;
    using System.Linq;
    namespace Demo
    {
        public class Program
        {
            static void Main()
            {
                List<string> sList = new List<string> { "Apple", "Bear", "Cat", "Dog" };
                var combinations = Combinations(sList, 3);
                foreach (var comb in combinations)
                    Console.WriteLine(string.Join(", ", comb));
                // If you must have the combinations in order of number of items, you would have to sort it by count.
                // This will be EXTREMELY SLOW for large sets of data!
                Console.WriteLine();
                combinations = Combinations(sList, 3).OrderBy(comb => comb.Count);
                foreach (var comb in combinations)
                    Console.WriteLine(string.Join(", ", comb));
            }
            /// <summary>Returns all the combinations of 'items' taken at most 'max' at a time.</summary>
            public static IEnumerable<List<T>> Combinations<T>(List<T> items, int max)
            {
                uint n = 1u << items.Count;
                for (uint i = 1; i < n; ++i)
                {
                    int c = numBitsSet(i);
                    if (c <= max)
                        yield return choose(items, c, i, n);
                }
            }
            static List<T> choose<T>(List<T> items, int count, uint mask, uint max)
            {
                var result = new List<T>(count);
                for (uint bit = 1, i = 0; bit < max; bit <<= 1, ++i)
                    if ((mask & bit) != 0)
                        result.Add(items[(int)i]);
                return result;
            }
            static int numBitsSet(uint i)
            {
                i = i - ((i >> 1) & 0x55555555);
                i = (i & 0x33333333) + ((i >> 2) & 0x33333333);
                return (int)(((i + (i >> 4)) & 0x0F0F0F0Fu) * 0x01010101u) >> 24;
            }
        }
    }
