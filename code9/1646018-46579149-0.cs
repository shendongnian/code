    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    
    namespace ConsoleApp1
    {
        //delegates are mostly defined outside of the class
        public delegate int addn(int num1, int num2);
    
        //the main class
    
        class Program
        {
            //delegate functions
            public static int add1(int num1, int num2)
            {
                return num1 + num2;
            }
    
            public static int add2(int num1, int num2)
            {
                return num1 * num2;
            }
    
            //entry
            public static void Main()
            {
                //here we can reference delegates as a class. its
                //called addf in this case.
    
                //first we init add1
                addn addf = new addn(add1);
                Console.WriteLine(addf(5, 5));
    
                //then we innit add2. note we dont add /*addn*/ in the beginning because
                //its already defined
                addf = new addn(add2);
                Console.WriteLine(addf(5, 5));
    
                //loop
    
                while (true) ;
            }
        }
    }
