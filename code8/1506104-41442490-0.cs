    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                List<List<int>> TestData = new List<List<int>>
                {
                     new List<int> { 1, 2, 3 },
                     new List<int> { 2, 1, 3 },
                     new List<int> { 6, 8, 3 },
                     new List<int> { 9, 2, 4 },
                };
                var values = TestData.SelectMany(x => x).GroupBy(x => x).ToList();
                var counts = values.Select(x => new { value = x.Key, times = x.Count() }).ToList();
                var times = counts.GroupBy(x => x.times).Select(x => new { key = x.Key, values = x.Select(y => y.value).ToList() }).OrderBy(x => x.key).ToList();
     
            }
     
        }
    }
