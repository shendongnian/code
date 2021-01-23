    using System;
    
    class Test
    {
        static void Main(string[] args)
        {
            int a = 10;
            Foo(ref a, ref a);
        }
        
        static void Foo(ref int x, ref int y)
        {
            x = 2;
            Console.WriteLine(y); // Prints 2, because x and y share a storage location
        }
    }
