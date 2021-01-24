    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string pattern = @"(?'name'[^\s]+)\s:\s(?'value'[\w\s\-]*|\d{4}-\d{2}-\d{2}\s\d{2}:\d{2})";
                string line = "TEST-END : 2017-01-08 15:51 PROGRAM : TLE8888QK-B2 BAU-NR : 95187193";
                MatchCollection matches = Regex.Matches(line, pattern, RegexOptions.RightToLeft);
                foreach (Match match in matches)
                {
                    Console.WriteLine("name : '{0}', value : '{1}'", match.Groups["name"].Value, match.Groups["value"].Value);
                    dict.Add(match.Groups["name"].Value, match.Groups["value"].Value);
                }
                DateTime date = DateTime.Parse(dict["TEST-END"]);
                Console.ReadLine();
            }
        }
    }
