    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication42
    {
        class Program
        {
            static void Main(string[] args)
            {
                int[] intervals = {3000, 4000, 5000,6000};
                List<List<int?>> data = new List<List<int?>>() {
                    new List<int?>() {2654},
                    new List<int?>() {3727,25},
                    new List<int?>() {3730,25},
                    new List<int?>() {4800,5},
                    new List<int?>() {5873,75},
                    new List<int?>() {6947}
                };
                var results = data.Select(x => new { index = intervals.Select((y, i) => new { index = i, max = y }).Where(z => x[0] < z.max).FirstOrDefault(), data = x }).ToList();
                var groups = results.GroupBy(x => x.index != null ? x.index.index : intervals.Length).Select(x => new { key = x.Key, data = x.Select(y => y.data).ToList() }).ToList();
            }
        }
    }
