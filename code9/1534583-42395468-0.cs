    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"(?:SELECT|INSERT)[\s\S]*?(?=\""|\;)";
            string input = @"""SELECT DISTINCT ""
    ""SELECT DISTINCT ""
    ""SELECT DISTINCT ""
    ""SELECT DISTINCT "";";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
