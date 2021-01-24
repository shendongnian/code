    using System;
    using System.IO;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace wbs
    {
        class Programm
        {
            static void Main(string[] args)
            {
                int a = 0;
                a = Convert.ToInt32(Console.ReadLine());
                if (a == 0)
                {
                    Console.WriteLine("Falsche eingabe.");
                }
                else
                {
                    List<double> list1 = new List<double>();
                    double n = 1;
    
                    for (int i = 1, j = 0; i <= a; i++)
                    {
                        n = n * i;
                        list1.Add(n);
                        Console.WriteLine("N: " + i + " Fakultät von N: " + list1[j++]);
                    }
                }
                Console.ReadKey();
            }
        }
    }
