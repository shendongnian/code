    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication56
    {
        class Program
        {
            static void Main(string[] args)
            {
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string input = "translate(700 210) rotate(-30)";
                string pattern = @"(?'command'[^\(]+)\((?'value'[^\)]+)\)";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach(Match match in matches.Cast<Match>())
                {
                    dict.Add(match.Groups["command"].Value, match.Groups["value"].Value);
                }
      
            }
        }
    }
