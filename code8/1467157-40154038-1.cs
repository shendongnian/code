    using System;
    using System.Linq;
    using System.Collections.Generic;
    
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = { 0, 1, 4, -99, -99, -99, 1, 
                    2, 7, 9, -99, -99, 3, 6, 8, -99, -99, 5 };
            foreach (var group in GroupByNegativeCounts(input))
            {
                Console.WriteLine(string.Join(", ", group));
            }
        }
        
        static IEnumerable<int[]> GroupByNegativeCounts(IEnumerable<int> input)
        {
            List<int> numbersToEmit = new List<int>();
            int negativeCount = 0;
            foreach (var value in input)
            {
                // We never emit anything when we see a negative number
                if (value < 0)                
                {
                    negativeCount++;
                }
                else
                {
                    // We emit numbers if we've previously seen negative
                    // numbers, and then we see a non-negative one.
                    if (negativeCount > 0)
                    {
                        int singles = Math.Max(numbersToEmit.Count - negativeCount, 0);
                        foreach (var single in numbersToEmit.Take(singles))
                        {
                            yield return new[] { single };
                        }
                        if (singles != numbersToEmit.Count)
                        {
                            yield return numbersToEmit.Skip(singles).ToArray();
                        }
                        negativeCount = 0;
                        numbersToEmit.Clear();
                    }
                    numbersToEmit.Add(value);
                }
            }
            // Emit anything we've got left at the end.
            foreach (var single in numbersToEmit)
            {
                yield return new[] { single };
            }
        }
    }
