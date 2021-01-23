    static string Create(string name)
    {
        Console.WriteLine(name);
        return name;
    }
    public static void Main()
    {
        var first = Create("Jeff");
        var second = Create("Alice");
        Console.WriteLine("Hello, {0}!", second);
    }
