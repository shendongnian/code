    using System;
    using System.Text.RegularExpressions;
    
    public class RegEx
    {
        public static void Main()
        {
            string pattern = @"(?<=cn=)[\w\s]+(?=\\ou.*?$)";
            string input = @"ou=company\ou=country\ou=site\cn=office\cn=name\ou=pet";
            
            foreach (Match m in Regex.Matches(input, pattern))
            {
                Console.WriteLine("{0}", m.Value);
            }
        }
    }
