        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Text;
        using System.Threading.Tasks;
        
        namespace test6
        {
            class Program
            {
                static char randomNumber(string s)
                {
        
                    Random rnd = new Random();
                    int index = rnd.Next(0, s.Length);
                    return s[index];
                }
        
                char number = randomNumber("123456789");
                static void Main(string[] args)
                {
                    Console.WriteLine(randomNumber("123456789"));
                    Console.ReadKey();
                }
            }
        }
