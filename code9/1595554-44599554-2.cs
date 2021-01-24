    using System;
    
    namespace SqlLike
    {
        class Program
        {
            static void Main(string[] args)
            {
                var findMe = "ABCHelloXYZ";
    
                // LIKE '......%'
                if (findMe.StartsWith("ABC"))
                {
                    Console.WriteLine("Yay");
                }
    
                // LIKE '%......'
                if (findMe.EndsWith("XYZ"))
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
