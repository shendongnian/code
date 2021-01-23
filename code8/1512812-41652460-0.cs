    using System;
    using System.Linq;
    
    namespace SO.MacakM.Answer
    {
        class Program
        {
            static void Main(string[] args)
            {
                var range = Enumerable.Range(1, 1000);
    
                Console.WriteLine("Using LINQ...");
                range.ToList().ForEach(i => Console.WriteLine(i));
    
                Console.WriteLine("Using PLINQ...");
                range.AsParallel().ForAll(i => Console.WriteLine(i));
    
                Console.Read();
            }
        }
    }
