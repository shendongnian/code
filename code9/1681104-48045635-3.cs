    private static Random rnd = new Random();
    static void Main(string[] args)
    {
        var colors = new List<NamedColor>
        {
            new NamedColor(ConsoleColor.Blue, "BLUE"),
            new NamedColor(ConsoleColor.Black, "BLACK"),
            new NamedColor(ConsoleColor.Red, "RED"),
            new NamedColor(ConsoleColor.Green, "GREEN"),
        };
        PrintColors(colors);
        for (int count = 0; count < 10; count++)
        {
            // Shuffle the items, then shuffle the names
            colors = colors.OrderBy(c => rnd.NextDouble()).ToList();
            colors = ShuffleNames(colors);
            PrintColors(colors);
        }
        Console.ResetColor();
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
