    class G<T> { public void f() { } }
    class A { }
    class B { }
    struct C { }
    struct D { }
    enum E : int { }
    static void Main(string[] args)
    {
        Console.WriteLine(typeof(G<object>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<string>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<A>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<B>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<C>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<D>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<E>).GetMethod("f").MethodHandle.Value);
        Console.WriteLine(typeof(G<int>).GetMethod("f").MethodHandle.Value);
    }
