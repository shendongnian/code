    public static void foo(bool doDebug = false)
    {   // <-- Conditional breakpoint here
        Console.WriteLine(doDebug);
    }
    public static void Main()
    {
        Console.WriteLine("No debug");
        foo();
        Console.WriteLine("Debug");
        foo(true);
        Console.ReadLine();
    }
