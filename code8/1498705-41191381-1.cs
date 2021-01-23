    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var nums = File.ReadAllLines("file.txt");
                var total = 0;
                foreach (var str in nums)
                {
                    total += int.Parse(str);
                }
                Console.WriteLine(total);
            }
        }
    }
