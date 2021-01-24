    public static void Main(string[] args)
    {
        var application = Application.Current;
        Console.WriteLine($"Application is {(application == null ? "null": "not-null")}");
        Console.ReadKey();
    }
