    using System;
    
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (Console.ReadKey().Key == ConsoleKey.Spacebar)
                {
                    Console.WriteLine("pressed it");
                }
                Console.ReadLine();
            }
        }
    }
