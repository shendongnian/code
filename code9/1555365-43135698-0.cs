    using System;
    using System.Linq;
    namespace StackOverflow_StatisticsLinq
    {
        class Program
        {
            static void Main(string[] args)
            {
                var reports = new int[][]
                {
                      new int[] { 80424, 9, 1, 7 }
                    , new int[] { 80424, 9, 2, 3 }
                    , new int[] { 80424, 9, 2, 2 }
                    , new int[] { 80423, 5, 1, 5 }
                    , new int[] { 80425, 4, 1, 5 }
                    , new int[] { 80423, 7, 1, 4 }
                    , new int[] { 80541, 7, 1, 5 }
                };
                var reportsTat5Plus = (from int[] r in reports
                                       where r[1] > 5
                                       orderby r[1] descending
                                      select r).GroupBy(r => r[0]).Select(r => r.First()) // ensure ids are distinct
                                      ;
                var average = reportsTat5Plus.Select(r => r[1])
                                             .Average();
                var mode = reportsTat5Plus.GroupBy(v => v)
                                          .OrderByDescending(g => g.Count())
                                          .First()
                                          .Select(r => r[1])
                                          .First()
                                          ;
                var median = reportsTat5Plus.Count() % 2 == 1 ? reportsTat5Plus.Skip(reportsTat5Plus.Count() / 2 + 1).Select(r => r[1]).First()
                                                              : reportsTat5Plus.Skip(reportsTat5Plus.Count() / 2 - 1).Take(2).Select(r => r[1]).Average()
                                                              ;
                Console.WriteLine($"Average: {average}");
                Console.WriteLine($"mode: {mode}");
                Console.WriteLine($"median: {median}");
                Console.ReadKey();
            }
        }
    }
