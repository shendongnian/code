    using System;
    using System.IO;
    
    namespace CountLinesInFiles_45194927
    {
        class Program
        {
            static void Main(string[] args)
            {
                int counter = 0;
                foreach (var line in File.ReadLines("c:\\Path\\To\\File.whatever"))
                {
                    counter++;
                }
                Console.WriteLine(counter);
                Console.ReadLine();
            }
        }
    }
