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
                string input = "level1.level2.level3 = item";
                string pattern = "^(?'keys'[^=]+)=(?'value'.*)";
                Match match = Regex.Match(input, pattern);
                string value = match.Groups["value"].Value.Trim();
                string[] keys = match.Groups["keys"].Value.Trim().Split(new char[] {'.'}, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                foreach (string key in keys)
                {
                    if (dict.ContainsKey("key"))
                    {
                        dict[key].Add(value);
                    }
                    else
                    {
                        dict.Add(key, new List<string>() { value });
                    }
                }
            }
        }
    }
