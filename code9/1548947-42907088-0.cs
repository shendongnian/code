    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication34
    {
        interface I { };
        class T1 : I { }
        class T2 : I { }
    
        class Program
        {
            static IEnumerable<I> i1 = new T1[] { new T1(), new T1() };
            static IEnumerable<I> i2 = new T2[] { new T2(), new T2() };
    
            static void Main(string[] args)
            {
                // Note: compile-time type of array members is IEnumerable<I>!
                IEnumerable<I>[] iEnumArr = new IEnumerable<I>[] { i1, i2 };
    
                // ... but run-time types are actually different.
                if (iEnumArr[0] is IEnumerable<T1>) { Console.WriteLine("Yes, it is enum of T1"); }
                if (iEnumArr[1] is IEnumerable<T2>) { Console.WriteLine("Yes, it is enum of T2"); }
            }
        }
    }
