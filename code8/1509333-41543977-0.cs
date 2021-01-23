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
                string input =
                    "COMPANY=ComanyName\n" +
                    "PRODUCT=ProductName\n" +
                    "SERIALMASK=123456789YYWWXXXX\n";
                string pattern = @"(?'name'\w+)=(?'value'\w+)";
                MatchCollection matches = Regex.Matches(input,pattern);
                foreach(Match match in matches)
                {
                    Console.WriteLine("Name : '{0}', Value : '{1}'", match.Groups["name"].Value, match.Groups["value"].Value);
                }
                Console.ReadLine();
                Dictionary<string, string> dict = matches.Cast<Match>()
                    .GroupBy(x => x.Groups["name"].Value, y => y.Groups["value"].Value)
                    .ToDictionary(x => x.Key, y => y.FirstOrDefault());
            }
        }
    }
