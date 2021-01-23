    using System;
    using System.Text.RegularExpressions;
    namespace Regex_GetSpecialPart_Demo
    {
        class Program
        {
            static void Main(string[] args)
            {
                string example = "starttest_exampleend";
                var match = Regex.Match(example, @"start(\S+)end");
                if (match.Success)
                {
                    var result = match.Result("$1");
                    Console.WriteLine(result);
                }
            
                Console.ReadLine();
            }
        }   
    }
