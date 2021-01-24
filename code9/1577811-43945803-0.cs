    using System;
    using System.Text.RegularExpressions;
    namespace StackOverflow_Example
    {
        class Program
        {
            static void Main(string[] args)
            {
                const string input = "Label: +1,234.56";
                string sanitized = Regex.Match(input, @"[0-9\.\+\-\,]+").Value; // filters out everything except digits (0-9), decimal points (.), signs (+ or -), and commas (,)
                double distance = Convert.ToDouble(sanitized);
                Console.WriteLine($"Input => \t\t{input}");             // Label: +1,234.56
                Console.WriteLine($"Standardized => \t{sanitized}");    // +1,234.56
                Console.WriteLine($"Distance => \t\t{distance}");       // 1234.56
                Console.ReadKey();
            }
        }
    }
