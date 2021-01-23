    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication1
    {
        class two_digt
        {
            private int dgt1, dgt2;
            public two_digt(int n)
            {//constructor
                dgt1 = n % 10;
                dgt2 = (n % 100) / 10;
            }
            public void print()
            {//funct to show what they've got
                Console.WriteLine("dgt1:" + dgt1);
                Console.WriteLine("dgt2:" + dgt2);
            }
        }
        class Program
        {
            static void Main(string[] args)
            {
                two_digt d1 = new two_digt(Convert.ToInt32(Console.ReadLine()));
                d1.print();
                two_digt d2 = new two_digt(Convert.ToInt32(Console.ReadLine()));
                //printing each objects
                d2.print();
                d1.print();
    
                Console.ReadLine();//just to keep console from closing
            }
        }
    }
     
