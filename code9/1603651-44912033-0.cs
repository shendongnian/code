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
                string input = "{something:something}Some data will be here";
                string pattern = @"\{(?'username'[^:]+):(?'password'[^\}]+)\}(?'data'.*)";
                Match match = Regex.Match(input,pattern);
                Console.WriteLine("Username : '{0}', Password : '{1}', Data : '{2}'",
                    match.Groups["username"].Value, match.Groups["password"].Value, match.Groups["data"].Value);
               Console.ReadLine();
            }
        }
    }
