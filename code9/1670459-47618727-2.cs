    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"&\*?([^&\*\d]+)";
            string input = @"&*cool&*it's&working&in&*all&case";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
