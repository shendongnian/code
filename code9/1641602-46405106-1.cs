    static void Main()
    {
        var task = Task.Run(new Func<int>(MyMethod));
    }
    static int MyMethod()
    {
        Console.WriteLine("MyMethod()");
        return 42;
    }
