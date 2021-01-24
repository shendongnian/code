    using System;
    using System.Collections.Generic;
    using System.Linq;
    
    namespace ConsoleApp1
    {
        class Program
        {
            static void Main(string[] args)
            {
                var src = new List<double>();
    
                for (int i = 0; i < 100; i++)
                    src.Add(0.25D);
                var dst = src.Skip(12).Take(24).Select(d => d * d * Math.Sqrt(d));
            }
        }
    }
