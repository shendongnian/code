    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text.RegularExpressions;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                IEnumerable<int> numbers = Enumerable.Range(1, 30);
    
                foreach (int n in numbers)
                {
                    var m = Regex.Match(n.ToString(), "^[25]+$");
    
                    if (m.Success)
                        Console.WriteLine(n);
                };
    
                Console.ReadKey();
            }
        }
    }
    
