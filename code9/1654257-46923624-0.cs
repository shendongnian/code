    using System;
    using System.Text.RegularExpressions;
    
    namespace WhileLoop
    {
        internal class Program
        {
            private static void Main(string[] args)
            {
                string words = Console.ReadLine();
    
                //input words
                Console.WriteLine(words);
    
    
                //check not alphabet or space, return invalid error message
                Regex rgx = new Regex("[^a-zA-Z ]+");
                if (rgx.IsMatch(words))
                {
                    Console.WriteLine("Please input alphabet or space only Ie. A-Z, a-z,");
                }
    
                Console.ReadLine();
    
            }
        }
    }
