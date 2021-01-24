    public static void foo()
    {   // <-- Conditional breakpoint here.
        Console.WriteLine(debugFoo);
    }
    public static bool debugFoo = false;
    public static void Main()
    {
        foo();
        debugFoo = true;
        foo();
        Console.ReadLine();
    }
