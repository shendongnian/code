    using System;
    
    namespace ConsoleApp
    {
        class Program
        {
            static void Main()
            {
                var t = new Triangle(2, 3, 5);
    
                //var Triangle = new Triangle(2);          // won't compile as no Triangle constructor can be found that takes 1 integer
                //var Triangle = new Triangle(2, 3, 5, 7); // won't compile as no Triangle constructor can be found that takes 4 integers
                //var Triangle = new Triangle(2, -3, 5);   // won't compile as the 2nd value is negative - and we've asked for unsigned for all 3 values
    
                Console.WriteLine("The triangle ({0}, {1}, {2}) has an area of {3}.", t.A, t.B, t.C, t.area());
    
                Console.ReadKey();
            }
        }
    
        public class Triangle
        {
            public uint A { get; set; }
            public uint B { get; set; }
            public uint C { get; set; }
    
            public Triangle(uint a, uint b, uint c)
            {
                this.A = a;
                this.B = b;
                this.C = c;
            }
    
            public uint area()
            {
                return A * B * C; // this needs fixing ...
            }
        }
    }
