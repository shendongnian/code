        using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"\bécumé\b";
            string input = @"123 écumé 456";
            RegexOptions options = RegexOptions.IgnoreCase | RegexOptions.CultureInvariant;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
