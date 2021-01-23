    using System;
    using System.Collections.Generic;
    namespace Demo
    {
        public class Program
        {
            static void Main()
            {
                var numbers = new[] {32183, 15883, 26917, 25459, 22757, 25236, 1657};
                int target = 50031;
                foreach (var subset in FindSubsetsForTotal(numbers, target))
                {
                    int subtotal = 0;
                    for (int i = subset.Item1; i <= subset.Item2; ++i)
                    {
                        Console.Write(numbers[i] + " ");
                        subtotal += numbers[i];
                    }
                    Console.WriteLine("Total: " + subtotal);
                }
            }
            public static IEnumerable<Tuple<int, int>> FindSubsetsForTotal(IList<int> numbers, int target)
            {
                int i = 0;
                while (i < numbers.Count)
                {
                    int end = endIndexOfNearestSum(numbers, i, target);
                    yield return new Tuple<int, int>(i, end); // The subset is from i..end inclusive. Return it.
                    i = end + 1;                              // On to the next subset.
                }
            }
            static int endIndexOfNearestSum(IList<int> numbers, int start, int target)
            {
                int sumSoFar    = 0;
                int previousSum = 0;
                for (int i = start; i < numbers.Count; ++i)
                {
                    sumSoFar += numbers[i];
                    if (sumSoFar > target)
                    {
                        if (Math.Abs(sumSoFar - target) < Math.Abs(previousSum - target))
                            return i;
                        return i - 1;
                    }
                    previousSum = sumSoFar;
                }
                return numbers.Count - 1;
            }
        }
    }
