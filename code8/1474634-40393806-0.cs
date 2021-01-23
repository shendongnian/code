    using System;
    
    class test
    {
        static void Foo(int x) { Console.WriteLine(x); }
        static void Foo(double x) { Console.WriteLine(x); }
        static void Foo(int x, float y) { Console.WriteLine(x); Console.WriteLine(y); }
        static void Foo(float x, int y) { Console.WriteLine(x); Console.WriteLine(y); }
        static void Main()
        {
            Foo(123);       // int
            Foo(123.0);     // double
            Foo(123, 123F); // int, float
            Foo(123F, 123); // float, int
        }
    }
