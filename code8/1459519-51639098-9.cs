    using System;
    using System.Reflection;
    
    namespace ReflectionExample
    {
        class Program
        {
            static void Main(string[] args)
            {
                var paramSet = new object[] { 1, 2.0, 3L };
                var mi = typeof(Program).GetMethod("Sum", BindingFlags.Public | BindingFlags.Static);
                Console.WriteLine(mi.Invoke(null, paramSet));
            }
    
            public static int Sum(int x, double y, long z)
            {
                return x + (int)y + (int)z;
            }
        }
    }
