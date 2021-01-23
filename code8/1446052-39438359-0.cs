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
                string input = "*fName   *   -sName!lName(London) ";
                string pattern = @"(?'word'\w+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                string output = string.Format("{0} {1} {2}, {3}",
                    matches[0].Groups["word"].Value,
                    matches[1].Groups["word"].Value,
                    matches[2].Groups["word"].Value,
                    matches[3].Groups["word"].Value
                    );
                Console.WriteLine(output);
                Console.ReadLine();
            }
        }
    }
