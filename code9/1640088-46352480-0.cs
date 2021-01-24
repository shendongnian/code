    using System;
    
    namespace ConsoleApp2
    {
        public class Program
        {
            private static void Main()
            { 
                double a = -178.125;
                double aBound = -1.875;
                double b = 0.000;
                double bBound = 180.000;
                double inc = 1.875;
    
                // counts from a to aBound (-178.125 to -1.875) and prints the values to console
                Console.WriteLine(a);
                while (a < aBound)
                {
                    a += inc;
                    Console.WriteLine(a);
                }
    
                // counts from b to bBound (0.000 to 180.000) and prints the values to console
                Console.WriteLine(b);
                while (b < bBound)
                {
                    b += inc;
                    Console.WriteLine(b);
                }
    
                Console.Read();
            }   
        }
    }
