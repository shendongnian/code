    static void Main()
    {
        var anon = new { Name = "Terry", Age = 34 };
        test(anon);
    }
    static void test(dynamic t)
    {
        Console.WriteLine(t.Age);
        Console.WriteLine(t.Name);
    }
