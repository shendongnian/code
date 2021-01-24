    using System;
    using System.Collections.Generic;
    
    class Test
    {
        static void Main()
        {
            Func<int,int> fn1 = new Func<int,int>(x => 3); 
            Func<int,int> fn2 = new Func<int,int>(x => x + 3);
            Func<int,int> fn3 = new Func<int,int>(x => x + 30);
            Func<int,double> fn4 = new Func<int,double>(x => x * 0.2);
            
            List<dynamic> pipeline = new List<dynamic> { fn1, fn2, fn3, fn4 };
            
            dynamic current = 6;
            foreach (dynamic stage in pipeline)
            {
                // current = stage(current) would work too, but I think it's less clear
                current = stage.Invoke(current);
            }
            Console.WriteLine($"Result: {current}");
        }
    }
