    using System;
    using System.Text.RegularExpressions;
    
    namespace RegexExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                foreach (Match match in Regex.Matches("ID: 12345<br />", @"ID:\s*(\d+)<br />"))
                    Console.WriteLine(match.Groups[1]);
            }
        }
    }
