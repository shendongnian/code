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
                    "Something-something", 
                    "-Something",
                    "SomethingSomething-",
                    "something-something-somthing",
                    "1234"
                };
                string pattern = @"^([A-Za-z]+[-\s]?[A-Za-z]+)+$";
                foreach (string input in inputs)
                {
                    Console.WriteLine("Input : '{0}', Match : '{1}'", input, Regex.IsMatch(input, pattern) ? "Yes" : "No");
                }
                Console.ReadLine();
            }
     
        }
    }
