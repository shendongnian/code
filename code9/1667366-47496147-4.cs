    using System;
    using System.Diagnostics;
    
    class Program
    {
        static void Main(string[] args)
        {
            var sw = Stopwatch.StartNew();
            for (int i = 0; i < 100000; i++)
            {
                Console.WriteLine(sw.Elapsed);
            }
        }
    }
