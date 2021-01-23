    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "DECLARE @MyVariable1 = 1\n" +
                    "DECLARE @MyVariable1 = 10\n" +
                    "DECLARE @MyVariable3 = 15\n" +
                    "DECLARE @MyVariable2 = 20\n" +
                    "DECLARE @MyVariable1 = 7\n" +
                    "DECLARE @MyVariable2 = 4\n" +
                    "DECLARE @MyVariable4 = 7\n" +
                    "DECLARE @MyVariable2 = 4\n";
                string pattern = @"@(?'name'[^\s]+)\s+=\s+(?'value'\d+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                var lines = matches.Cast<Match>()
                    .Select((x, i) => new { name = x.Groups["name"].Value, value = x.Groups["value"].Value, index = i })
                    .GroupBy(x => x.name)
                    .Select(x => x.Select((y, i) =>  new { 
                        index = y.index,  
                        s = i == 0 
                           ? string.Format("DECLARE @{0} = {1}", x.Key, y.value)  
                           : string.Format("@{0} = {1}", x.Key, y.value) 
                    }))
                    .SelectMany(x => x)
                    .OrderBy(x => x.index)
                    .Select(x => x.s)
                    .ToArray();
                foreach (string line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();
            }
        }
    }
