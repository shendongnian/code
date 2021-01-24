    public class AB<T>
    {
        public static void Foo()
        {
            Console.WriteLine(typeof(T));
        }
    }
    
    public class A : AB<A> { }
    
    public class B : AB<B> { }
    A.Foo(); // A
    B.Foo(); // B
