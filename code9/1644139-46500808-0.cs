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
                                      "<eid=1>",
                                      "<eid = >",
                                      "<exd = 1>", 
                                      "< eid = 1000>"
                                  };
                string pattern = @"\<\s*eid\s*=\s*(?'number'\d+)\s*\>";
                foreach (string input in inputs)
                {
                    Match  match = Regex.Match(input, pattern);
                    if (match.Success)
                    {
                        Console.WriteLine("input : '{0}' Does Match, number = '{1}'", input, match.Groups["number"]);
                    }
                    else
                    {
                        Console.WriteLine("input : '{0}' Does not Match", input);
                    }
                }
                Console.ReadLine();
            }
        }
    }
