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
                int i = 0;
                Console.WriteLine($"Target = {target}\n");
                while (i < numbers.Length)
                {
                    int end = endIndexOfNearestSum(numbers, i, target);
                    // The subset is from i..end inclusive. Print it out.
                    int subtotal = 0;
                    for (int j = i; j <= end; ++j)
                    {
                        Console.Write(numbers[j] + " ");
                        subtotal += numbers[j];
                    }
                    Console.WriteLine("Total: " + subtotal);
                    i = end + 1; // On to the next subset.
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
