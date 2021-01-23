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
                    "< 0.22",
                    "< 32.45",
                     "> 2.0"
                                 };
                string pattern = @"(?'sign'[\<\>])\s+(?'integer'\d+).(?'fraction'\d+)";
                decimal number = 0;
                foreach(string input in inputs)
                {
                    Match match = Regex.Match(input, pattern);
                    if(match.Groups["sign"].Value == ">")
                    {
                       number = decimal.Parse(match.Groups["integer"].Value  + "." + match.Groups["fraction"].Value);
                       number += decimal.Parse("." + new string('0', match.Groups["fraction"].Value.Length) + "1");
                    }
                    else
                    {
                       number = decimal.Parse(match.Groups["integer"].Value  + "." + match.Groups["fraction"].Value);
                       number -= decimal.Parse("." + new string('0', match.Groups["fraction"].Value.Length) + "1");
                    }
                        Console.WriteLine(number.ToString());
                }
                Console.ReadLine();
            }
        }
    }
