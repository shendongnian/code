    using System;
    
    namespace Test
    {
        struct Source1
        {
            public float x1;
            public float x2;
            public float x3;
    
            public static implicit operator Target(Source1 value)
            {
                return new Target() { x1 = value.x1, x2 = value.x2, x3 = value.x3 };
            }
        }
    
        struct Target
        {
            public float x1;
            public float x2;
            public float x3;
        }
    
        public class Program
        {
            static void Main(string[] args)
            {
                var source = new Source1() { x1 = 1, x2 = 2, x3 = 3 };
                Target target = source;
    
                Console.WriteLine(target.x2);
    
                Console.ReadLine();
            }
        }
    }
