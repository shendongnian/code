    static void Main(string[] args)
    {
        var string1 = "Testmonial";
        var string2 = "Test";
        var intersect = string1.Intersect(string2);
        var except = string1.Except(string2);
        Console.WriteLine("Intersect");
        foreach (var r in intersect)
        {
            Console.Write($"{r} ");
        }
        Console.WriteLine("Except");
        foreach (var r in except)
        {
            Console.Write($"{r} ");
        }
        Console.ReadKey();
    }
