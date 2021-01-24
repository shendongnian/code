    using System;
    
    namespace Stackoverflow.Com
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var scr = new Scrapping("https://stackoverflow.com/questions");
                scr.Start(36); 
                Console.ReadLine();
            }
        }
    }
