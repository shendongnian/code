    using System;
    using System.Linq;
    
    public class SortProblem
    {
        public static void Main()
        {
            var result = new[]
            {
                10, 10, 5, 2, 2, 5, 6, 7, 8, 15, 4, 4, 4, 2, 3, 5, 5, 36, 32, 623, 7, 475, 7, 2, 2, 44, 5, 6, 7, 71, 2
            }.Select((element, idx) => new { Value = element, OriginalIndex = idx }).OrderByDescending(item => item.Value).ToList(); // The last one only needed to persist the result set and avoid double processing
    
            Console.WriteLine(string.Join(" ", result.Select(item => item.OriginalIndex)));
            Console.WriteLine(string.Join(" ", result.Select(item => item.Value)));
        }
    }
