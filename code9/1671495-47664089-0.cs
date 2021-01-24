    using System;
    using System.IO;
    
    namespace ConsoleApplication4
    {
        class Program
        {
            static void Main(string[] args)
            {
                string[] lines = File.ReadAllLines(@"c:\Developer\TestFile.txt");
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
                Console.ReadLine();
            }
        }
    }
