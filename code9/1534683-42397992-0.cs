    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^[0]\d{10}$";
            string input = @"08036496516
    07055483123
    08078785455
    09014587958";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
