    using System;
    using System.Collections.Generic;
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> ds = new Dictionary<string, int>;
            Random r = new Random();
            for (int i = 0; i < 100000000; i++) {
                string s = Guid.NewGuid().ToString();
                
                d[s] = r.Next(0, 1000000);
                if (i % 100000 == 0)
                {
                    Console.Out.WriteLine("Dict size: " + d.Count);
                }
            }
        }
    }
