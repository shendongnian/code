    using System;
    namespace ABCD
    {
        public class ClassA<T>
        {
            T t;
            public T func(T num)
            {
                t = (T)(object)(2 * (double)(object)num);//t has to be assigned in this method (not in func2)
                ref T x = ref func2();
                t = (T)(object)(3 * (double)(object)num);//t will be reassigned here, and I want this to be reflected in x
                return x;//I want x to be 9 not 6
            }
            public ref T func2()
            {
                return ref t;
            }
        }
    
        public class Program
        {
            public static void Main(string[] args)
            {
                ClassA<double> a = new ClassA<double>();
                Console.WriteLine(a.func(3.0));
                Console.ReadLine();
            }
        }
    }
