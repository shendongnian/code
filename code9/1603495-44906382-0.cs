    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace Test
    {
        public class Program
        {
            class Pair<K, V>
            {
                public Pair(K key, V value)
                {
                    Key = key;
                    Value = value;
                }
                public K Key { get; set; }
                public V Value { get; set; }
            }
    
            static void Main(string[] args)
            {
                string[] src = { "ola", "super", "isel", "ole", "mane", "xpto", "aliba" };
                var pairs = src.GroupBy(s => s.Length)
                    .Select(@group => new Pair<int, IEnumerable<string>>(@group.Key, @group));
    
                foreach (var pair in pairs)
                {
                    Console.WriteLine("{0}: {1}", pair.Key, string.Join(", ", pair.Value));
                }
    
                Console.ReadLine();
            }
        }
    }
