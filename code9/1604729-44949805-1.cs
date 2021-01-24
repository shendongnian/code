    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        public class Program
        {
            private static IEnumerable<int> GetTotalsPerColumn(int[][] inputData)
            {
                var data = inputData.SelectMany(z =>
                    {
                        var index = 0;
                        return z.Select(item => new { item, index = index++ });
                    })
                    .GroupBy(z => z.index)
                    .OrderBy(z => z.Key)
                    .Select(y => y.Select(z => z.item).Sum()
                );
    
                return data;
            }
    
            static void Main(string[] args)
            {
                var inputData = new[] {
                          new[] { 1, 2, 3, 5},
                          new[] { 3, 4, 5, 6},
                          new[] { 5, 4, 3},
                        };
    
                var values = GetTotalsPerColumn(inputData);
    
                foreach (var value in values)
                {
                    Console.WriteLine(value);
                }
    
                Console.ReadLine();
            }
        }
    }
