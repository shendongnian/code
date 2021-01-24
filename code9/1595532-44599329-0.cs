    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var randoms = GenerateRandoms(10, 1, 10).OrderBy(v => v);
                foreach (var random in randoms)
                {
                    Console.WriteLine(random);
                }
    
                Console.ReadLine();
            }
    
            private static int[] GenerateRandoms(int randomCount, int min, int max)
            {
                var length = max - min + 1;
                if (randomCount > length) { throw new ArgumentException($"Cannot generate {randomCount} random numbers between {min} and {max} (inclusive)."); }
    
                var values = new List<int>(length);
                for (var i = 0; i < length; i++)
                {
                    values.Insert(i, min + i);
                }
    
                var randomGenerator = new Random();
                var randoms = new List<int>();
                for (var i = 0; i < randomCount; i++)
                {
                    var val = randomGenerator.Next(0, values.Count);
                    randoms.Add(values[val]);
                    values.RemoveAt(val);
                }
    
                return randoms.ToArray();
            }
        }
    }
