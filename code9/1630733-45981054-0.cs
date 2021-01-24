    static void Main(string[] args)
    {
        var a = "foo";
        var b = "foo";
        Console.WriteLine(string.IsInterned(a));
        Console.WriteLine(ReferenceEquals(a, b));
        Console.ReadLine();
    }
