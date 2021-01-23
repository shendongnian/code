    using System;
    public class Program
    {
        static void Main()
        {
            var a = new Test {A = false, B = 0};
            var b = new Test {A = true,  B = 0};
            var c = new Test {A = false, B = 1};
            var d = new Test {A = false, B = 2};
            var e = new Test {A = false, B = 3};
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
            Console.WriteLine(c.GetHashCode());
            Console.WriteLine(d.GetHashCode());
            Console.WriteLine(e.GetHashCode());
        }
    }
    public struct Test
    {
        public bool A;
        public int  B;
    }
 
    Output
    346948956
    346948956
    346948956
    346948956
    346948956
