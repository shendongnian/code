    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(\w+)(?:\:)(\w+)";
            string input = @"aa bb cc color:red dd ee ff";
    
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' full math at index {1}.", m.Value, m.Index);
                Console.WriteLine("Capture group 1: '{0}'", m.Groups[1].Value);
                Console.WriteLine("Capture group 2: '{0}'", m.Groups[2].Value);
            }
        }
    }
