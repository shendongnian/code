    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            int a = 10;
            Foo(ref a, () => a++);
        }
        
        static void Foo(ref int x, Action action)
        {
            Console.WriteLine(x); // 10
            action();             // Changes the value of a
            Console.WriteLine(x); // 11
            x = 5;
            action();
            Console.WriteLine(x); // 6
        }
    }
