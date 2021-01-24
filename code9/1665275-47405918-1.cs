    using System;
    using System.Text.RegularExpressions;
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(\d+)";
            string input = @"OL/12/15/NR/17/21";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
