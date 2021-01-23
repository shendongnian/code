    static void Test()
    {
        Console.WriteLine(IsBoxedDefault(0)); // true
        Console.WriteLine(IsBoxedDefault("")); // false (reference type)
        Console.WriteLine(IsBoxedDefault(1));// false
        Console.WriteLine(IsBoxedDefault(DateTime.Now)); // false
        Console.WriteLine(IsBoxedDefault(new DateTime())); // true
    }
