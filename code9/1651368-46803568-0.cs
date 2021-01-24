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
                string input = "Stock 350 mts 500 pcs 750 mts 1000 mts";
                // any word characters followed by any white spaces
                // followed by any number of digits
                string pattern = @"(?'name'\w+)\s+(?'quantity'\d+)";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    Console.WriteLine("Name : '{0}', Qnty : '{1}'", match.Groups["name"].Value, match.Groups["quantity"].Value);
                }
                Console.ReadLine();
            }
        }
    }
