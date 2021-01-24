    using System;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                string html = @"
                    <div class=""simple"">
                        < span > Text </ span >
                    </ div > 
                ";
    
                Console.WriteLine(html);
    
            }
        }
    }
