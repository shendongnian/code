    using System;
    using System.Threading;
    
    namespace ConsoleApplication
    {
        public class Program
        {
            public static void Main()
            {
                Console.WriteLine("Timer Start!");
    
                Thread.Sleep(5000);
                Console.Clear();
                Console.WriteLine("End");
    
                Console.ReadKey();
            }
        }
    }
