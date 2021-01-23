    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication1
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                string input = "[Fruit] or [Pears]";
                string pattern = @"\[(?'fruit'[^\]]+)\]";
                MatchCollection matches = Regex.Matches(input, pattern);
                foreach (Match match in matches)
                {
                    Console.WriteLine("fruit : '{0}'", match.Groups["fruit"].Value);
                }
                Console.ReadLine();
            }
        }
    }
