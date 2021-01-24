    using System;
    using System.Text.RegularExpressions;
    
    namespace RemoveSpecialCharactersConsoleApp
    {
        class Program
        {
            static void Main(string[] args)
            {
                string line = "C#%3HA#*$03IR";
                line = RemoveSpecialCharacters(line);
                Console.WriteLine(line);
                Console.Read();
            }
    
            public static string RemoveSpecialCharacters(string input)
            {
                Regex r = new Regex("(?:[^a-z]|(?<=['\"])s)", RegexOptions.IgnoreCase | RegexOptions.CultureInvariant | RegexOptions.Compiled);
                return r.Replace(input, string.Empty);
            }
        }
    }
