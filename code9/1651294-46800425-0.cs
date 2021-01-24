    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace Test
    {
        class Program
        {
            static void Main(string[] args)
            {
                Stopwatch stopwatch = new Stopwatch();
    
                List<string> regexes = new List<string> {
                    @"[0-9]{4}",
                    @"^.*([0-9]{4})"
                };
    
                foreach (string regex in regexes)
                {
                    List<TimeSpan> times = new List<TimeSpan>();
    
                    for (int i = 0; i < 100; i++)
                    {
                        stopwatch.Start();
    
                        Regex myRegex = new Regex(regex, RegexOptions.RightToLeft);
                        string strTargetString = @"1233Chocolatechipcookie2017!";
    
                        for (int j = 0; j < 100000; j++)
                        {
                            foreach (Match myMatch in myRegex.Matches(strTargetString))
                            {
                            }
                        }
    
                        stopwatch.Stop();
                        times.Add(stopwatch.Elapsed);
                    }
                    TimeSpan average = TimeSpan.FromMilliseconds(times.Average(t => t.TotalMilliseconds));
                    Console.WriteLine($"Elapsed={average}");
                }
    
                Console.Read();
            }
        }
    }
