    public static void Main()
    {
        Console.WriteLine("Using lambda");
        string userInput = "1";
        var logbook = new List<string[]> { new string[] { "1", "2" } };
        var entries = logbook.Where(entry => entry.Any(item => item.IndexOf(userInput, StringComparison.OrdinalIgnoreCase) > -1));
        foreach (var entry in entries)
        {
            Console.WriteLine(string.Join(", ", entry));
        }
    }
