    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    class Largest
    {
        double[] a1;
        double[] a2;
    
        public Largest()
        {
        }
    
        public void compareArray()
        {
    
            if (a1.Max() > a2.Max())
            {
                foreach (var x in a1)
                {
                    Console.WriteLine(x.ToString());
                }
                Console.ReadKey();
            }
            else
            {
                foreach (var x in a2)
                {
                    Console.WriteLine(x.ToString());
                }
                Console.ReadKey();
            }
        }
    
        static void Main(string[] args)
        {
            Largest compare = new Largest();
            compare.a1 = new double[5] { 14, 7, 3, 7, 1 };
            compare.a2 = new double[5] { 13, 24, 3, 6, 11};
            compare.compareArray();
            Console.ReadKey();
        }
    }
