    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    public class SortProblem
    {
        public static void Main()
        {
            Console.WriteLine(string.Join(" ", Sort()));
        }
    
        public static IEnumerable<int> Sort()
        {
            var array = new[]
            {
                10, 10, 5, 2, 2, 5, 6, 7, 8, 15, 4, 4, 4, 2, 3, 5, 5, 36, 32, 623, 7, 475, 7, 2, 2, 44, 5, 6, 7, 71, 2
            };
    
            for (int index = 0; index < array.Length; index++)
            {
                int max = index;
    
                for (int elemIndex = index + 1; elemIndex < array.Length; elemIndex++)
                {
                    if (array[elemIndex] > array[max])
                    {
                        max = elemIndex;
                    }
                }
    
                int tmp = array[index];
                array[index] = array[max];
                array[max] = tmp;
    
                yield return max;
            }
        }
    }
