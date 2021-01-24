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
                string input = "1[::]One[::]2[::]Two[::]3[::]Three";
                string pattern = @"(?'key'[^\[]+)\[::\](?'value'[^\[]+)(\[::\])?";
                MatchCollection matches = Regex.Matches(input, pattern);
                Dictionary<int, string> dict = matches.Cast<Match>().GroupBy(x => x.Groups["key"].Value, y => y.Groups["value"].Value)
                    .ToDictionary(x => int.Parse(x.Key), y => y.FirstOrDefault()); 
            }
        }
    }
