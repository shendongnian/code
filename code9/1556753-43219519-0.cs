    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;
    using System.Threading.Tasks;
    namespace ConsoleApplication25
    {
    class Program
    {
        static char[] values;
        static void Main(string[] args)
        {
            //Increase Console Buffer Height
            Console.BufferHeight = Int16.MaxValue - 1;
           
            foreach (var line in File.ReadAllLines("Labyrint.txt", Encoding.UTF8).Skip(1))
            {
                values = line.ToCharArray();
                Console.WriteLine(values);
                
            }
            //finds the character on index 0
            Console.WriteLine(values[0]);
            }
        }
    }
 
