    using System;
    using System.Collections.Generic;
    
    namespace Bob
    {
        public class Program
        {
            static void Main(string[] args)
            {
                var hash = new HashSet<int>();
                Console.WriteLine(hash.Count);
                Add(hash);
                Console.WriteLine(hash.Count);
                Console.ReadLine();
            }
    
            private static void Add(dynamic hash)
            {
                hash.Add(1);
            }
        }
    }
