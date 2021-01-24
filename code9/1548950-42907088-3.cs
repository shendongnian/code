    using System;
    using System.Collections.Generic;
    
    namespace ConsoleApplication34
    {
        interface I { };
        class T1 : I { }
        class T2 : I { }
    
        class Program
        {
            // strongly typed arrays get assigned to base type IEnumerables.
            static IEnumerable<I> i1 = new T1[] { new T1(), new T1() };
            static IEnumerable<I> i2 = new T2[] { new T2(), new T2() };
    
            static void Main(string[] args)
            {
                // Note: compile-time type of array elements is IEnumerable<I>!
                IEnumerable<I>[] iEnumArr = new IEnumerable<I>[] { i1, i2 };
    
                foreach (IEnumerable<I> ie in iEnumArr)
                {
                    // ... but the run-time types of the IEnumerable objects 
                    // are actually different.
                    Console.WriteLine("ienumerable is of T1: " + (ie is IEnumerable<T1>));
                    Console.WriteLine("ienumerable is of T2: " + (ie is IEnumerable<T2>));
                }
            }
        }
    }
