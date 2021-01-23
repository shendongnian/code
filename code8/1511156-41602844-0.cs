    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication41
    {
        class Program
        {
            static void Main(string[] args)
            {
                string input =
                    "Int section : 203\n" +
                    "String start_time : 00:16:38,731\n" +
                    "String end_time : 00:16:41,325\n" +
                    "String Content :\n" +
                    "Happy Christmas.\n" +
                    "your arse I pray God it's our last.\n";
                string pattern =
                   @"Int section :\s+(?'section'\d+)\s+" +
                   @"String start_time :\s+(?'start'[\d:,]+)\s+" +
                   @"String end_time :\s+(?'end'[\d:,]+)\s+" +
                   @"String Content :(?'content'[^$]+)";
                Match match = Regex.Match(input, pattern, RegexOptions.Multiline);
                Console.WriteLine(match.Groups["section"].Value.Trim());
                Console.WriteLine("{0} --> {1}", match.Groups["start"].Value.Trim(), match.Groups["end"].Value.Trim());
                Console.WriteLine(match.Groups["content"].Value.Trim());
                Console.ReadLine();
            }
        }
     
    }
