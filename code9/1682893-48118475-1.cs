    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string content = "FL2 (77) Flashing,77,a=1.875,A=90.0,b=3.625,B=95.0,c=1.375,C=175.0,d=2.5,hem=0.5,16GA-AL,";
                const string regexPattern = "(?<=[,| ])[a-zA-Z]=([0-9|.|-])+";
                string singleMatch = new Regex(regexPattern).Match(content).ToString();
                Console.WriteLine(singleMatch); // a=1.875
                MatchCollection matchList = Regex.Matches(content, regexPattern);
                var matches = matchList.Cast<Match>().Select(match => match.Value).ToList();
                Console.WriteLine(string.Join(", ", matches)); // a=1.875, A=90.0, b=3.625, B=95.0, c=1.375, C=175.0, d=2.5
            }
        }
    }
