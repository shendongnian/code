    using System;
    using System.Text.RegularExpressions;
    
    namespace PatternMatching
    {
        class Program
        {
            static void Main()
            {
                string pattern = @"(\d+) (\w+)";
    
                string[] strings = { "123 ABC", "ABC 123", "CD 45678", "57998 DAC" };
    
                foreach (var s in strings)
                {
                    Match result = Regex.Match(s, pattern);
    
                    if (result.Success)
                    {
                        Console.WriteLine("Match: {0}", result.Value);
                    }
                }
    
                Console.ReadKey();
            }
        }
    }
