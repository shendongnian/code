    using System;
    public class Program
    {
        static void Main()
        {
            var a = new Test {A = 0, B = 0};
            var b = new Test {A = 1, B = 0};
            var c = new Test {A = 0, B = 1};
            var d = new Test {A = 0, B = 2};
            var e = new Test {A = 0, B = 3};
            Console.WriteLine(a.GetHashCode());
            Console.WriteLine(b.GetHashCode());
            Console.WriteLine(c.GetHashCode());
            Console.WriteLine(d.GetHashCode());
            Console.WriteLine(e.GetHashCode());
        }
    }
    public struct Test
    {
        public int A;
        public int B;
    }
    Output:
    346948956
    346948957
    346948957
    346948958
    346948959
 
