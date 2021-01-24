    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    namespace StackOverflow_RegexMatching
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                String content = "FL2 (77) Flashing,77,a=1.875,A=90.0,b=3.625,B=95.0,c=1.375,C=175.0,d=2.5,hem=0.5,16GA-AL,";
                string singleMatch = new Regex("[a-zA-Z]=([0-9|.|-])+").Match(content).ToString();
                Console.WriteLine(singleMatch); // a=1.875
                MatchCollection matchList = Regex.Matches(content, "[a-zA-Z]=([0-9|.|-])+");
                var matches = matchList.Cast<Match>().Select(match => match.Value).ToList();
                Console.WriteLine(string.Join(", ", matches)); // a=1.875, A=90.0, b=3.625, B=95.0, c=1.375, C=175.0, d=2.5, m=0.5
            }
        }
    }
