    using System;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                string s = @"ir KAS gi mus nugales.
    jei!mes MIRTI NEBIJOM,
    JEIGU mes nugalejom mirti
    DZUKAS";
                Match result = Regex.Match(s, "([A-Z]+)", RegexOptions.RightToLeft);
    
                Console.WriteLine(result.Value);
    
                Console.ReadKey();
            }
        }
    }
    
