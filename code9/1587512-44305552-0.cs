    using System.Collections.ObjectModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication57
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] inputs = {
                                    "ABC - CA",
                                    "ABC - C20"
                                };
                string pattern = @"\w+\s+-\s+\w+\d+$";
                foreach (string input in inputs)
                {
                    Console.WriteLine("Input : '{0}' Matches : '{1}'", input, Regex.IsMatch(input,pattern) == true ? "True" : "False");
                }
                Console.ReadLine();
            }
     
        }
     
    }
