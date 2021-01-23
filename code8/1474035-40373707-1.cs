    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"[a-zA-Z\/]+";
            string input = @"...
    1.1SMITH/JOHN 2.1SMITH/SARA
    ...
    1.1Parker/Sara/Amanda.CH07/Elizabeth.IN03";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
