    using System;
    
    class Test
    {
        static void Main()
        {
            int x = 0;
            RefTwo(ref x, ref x);
        }
        
        static void RefTwo(ref int a, ref int b)
        {
            Console.WriteLine(a); // 0
            b = 5;
            Console.WriteLine(a); // 5!
        }
    }
