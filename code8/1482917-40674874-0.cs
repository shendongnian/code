    using System;
    namespace Rextester
    {
        public class Program
        {
            public static void Main(string[] args)
            {
                Console.WriteLine ( A.GetName() == "A" && B.GetName() == "B" );
            }
        }
        class C<T> {
            public static string GetName(){
                return typeof(T).Name;
            }
        }
        class A : C<A>{ }
        class B : C<B> { }
    
    }
