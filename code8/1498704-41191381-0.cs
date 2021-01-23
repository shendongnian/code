    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication2
    {
        class Program
        {
            static void Main(string[] args)
            {
                var str = "1 2 3 4 5";
                var total = str.Split(' ').Sum(int.Parse);
                Console.WriteLine(total);
            }
        }
    }
