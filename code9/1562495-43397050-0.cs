    class G<T> { public void f() { } }
    class A { }
    class B { }
    struct C { }
    static void Main(string[] args)
    {
        Console.WriteLine(typeof(G<A>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<B>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<C>).GetMethod("f").MethodHandle.Value);
    }
