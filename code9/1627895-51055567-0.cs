    using System;
    
    class Program
    {
        static void Main()
        {
            bool a = false;
            bool x;
            bool y = true;
            
            if (true & (y && (x = a)))
            {
                Console.WriteLine(x);
            }
        }
    }
