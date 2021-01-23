    static void Main(string[] args)
    {
        var loggBook = new List<string[]>
        {
            new[] {"1", "2"},
            new[] {"3", "4"},
            new[] {"5", "6"}
        };
        foreach (var x in loggBook)
        {
            var s = string.Join("\n", x);
            Console.WriteLine(s);
        }
        Console.ReadLine();
    }
