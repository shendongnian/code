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
                string[] inputs = {  
                                    "input string => captured group's value",
                                    "SpecificArbitraryStringString => ArbitraryString // inside",
                                    "SpecHAHAHALOLificString => HAHAHALOL",
                                    "SpecificStringYOLO => YOLO // adjacent",
                                    "SpecificStrisadng => sad",
                                    "itsABea8tifulDaySpecificString => itsABea8tifulDay // also adjacent",
                                    "Show to be a heartbreakerpecificString => how to be a heartbreaker",
                                    "SpecificSt this is the last example ring => this is the last example"
                                  };
                Dictionary<string, string> dict = new Dictionary<string, string>();
                string pattern = "^(?'name'[^=]+)=>(?'value'.*)";
                foreach (string input in inputs)
                {
                    Match match = Regex.Match(input, pattern);
                    dict.Add(match.Groups["name"].Value.Trim(), match.Groups["value"].Value.Trim());
                }
            }
        }
    }
