        using System;
        using System.Collections.Generic;
        using System.Linq;
        class Solution
        {
            static void Main(String[] args)
            {
                List<string> tests = new List<string>();
                var testCount = int.Parse(Console.ReadLine());
                for (var i = 0; i < testCount; i++)
                {
                    tests.Add(Console.ReadLine());
                }
                foreach (var s in tests)
                {
                    Console.WriteLine($"{new string(s.Where((x, i) => i % 2 == 0).ToArray())} {new string(s.Where((x, i) => i % 2 != 0).ToArray())}");
                }
            }
        }
