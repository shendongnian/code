    using System;
    using System.Linq;
    using System.Collections.Concurrent;
    
    class Test
    {
        static void Main()
        {
            var dict = new ConcurrentDictionary<int, int>
            {
                [10] = 15,
                [20] = 5,
                [30] = 10
            };
            foreach (var key in dict.Keys)
            {
                dict.AddOrUpdate(key, 0, (k, v) => v + 1);
            }
            Console.WriteLine(string.Join("\r\n", dict.Select(kp => $"{kp.Key}={kp.Value}")));
        }
    }
