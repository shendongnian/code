    using System;
    using System.Text.RegularExpressions;
    
    public class Example
    {
        public static void Main()
        {
            string pattern = @"^([a-zA-Z\d]{3,25}):([a-zA-Z\d]{3,30})$";
            string input = @"xxxxx:xxxxx
    1adfasfdfasdfsdfsfsfssfsd:1asfdsfsdfsafsdfsadfdfsdfadf2s
    sfsd12321:12sfs3123
    @342fdfasd:1dsadafdsfs";
            RegexOptions options = RegexOptions.Multiline;
            
            foreach (Match m in Regex.Matches(input, pattern, options))
            {
                Console.WriteLine("'{0}' found at index {1}.", m.Value, m.Index);
            }
        }
    }
