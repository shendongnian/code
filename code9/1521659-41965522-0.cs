    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"([A-Z]+\d*)";
            string substitution = @"$1_NEW";
            string input = @"WORD, WORD1, WORD2";
            RegexOptions options = RegexOptions.Multiline;
            
            Regex regex = new Regex(pattern, options);
            string result = regex.Replace(input, substitution);
            Console.WriteLine(result);
        }
    }
