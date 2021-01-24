    using System;
    
    namespace SqlLike
    {
        class Program
        {
            static void Main(string[] args)
            {
                var findMe = "#Hello%";
    
                // LIKE '......%'
                if (findMe.StartsWith("#"))
                {
                    Console.WriteLine("Yay");
                }
    
                // LIKE '%......'
                if (findMe.EndsWith("%"))
                {
                    Console.WriteLine("Woohoo");
                }
    
                // LIKE '%......%'
                if (findMe.Contains("Hello"))
                {
                    Console.WriteLine("JackPot!!");
                }
    
                Console.ReadLine();
            }
        }
    }
