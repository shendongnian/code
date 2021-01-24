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
                   "Where Name like '%A%'",
                   "Where Name like '%A'",
                   "Where Name like 'A%'",
                   "Where Name like '%A%B%C'",
                   "Where Name Like %%",
                   "Where Name Like %"
                                  };
                string pattern = @"Where\s+[A-Za-z]+\s+like\s+(?'wildcard'.*)";
                foreach (string input in inputs)
                {
                    Boolean valid = false;
                    Match match = Regex.Match(input, pattern);
                    if (match.Success)
                    {
                        string wildcard = match.Groups["wildcard"].Value;
                        int percentCount = wildcard.Where(x => x == '%').Count();
                        if ((percentCount == 1) || (percentCount == 2))
                        {
                            string wildcardPattern = "'%A%'|'%A'|'A%'";
                            Match match2 = Regex.Match(wildcard, wildcardPattern);
                            if (match2.Success) valid = true;
                        }
                    }
                    Console.WriteLine("Success = '{0}', string = '{1}'", valid ? "true" : "false", input);
                }
                Console.ReadLine();
            }
        }
    }
