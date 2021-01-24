    using System;
    
    class Test
    {
        private Func<object> CreateFunc()
        {
            return () => new object();
        }
        
        static void Main()
        {
            Test t = new Test();
            var f1 = t.CreateFunc();
            var f2 = t.CreateFunc();
            Console.WriteLine(ReferenceEquals(f1, f2));
        }
    }
