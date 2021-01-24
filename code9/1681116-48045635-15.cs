    private static Random rnd = new Random();
    static void Main(string[] args)
    {
        var correctColors = new NamedColor[]
        {
            new NamedColor(ConsoleColor.Blue, "BLUE"),
            new NamedColor(ConsoleColor.Black, "BLACK"),
            new NamedColor(ConsoleColor.Red, "RED"),
            new NamedColor(ConsoleColor.Green, "GREEN"),
        };
        PrintColors(correctColors);
        for (int count = 0; count < 10; count++)
        {
            // Shuffle the items, then shuffle the names
            var shuffledColors = correctColors.OrderBy(c => rnd.NextDouble()).ToArray();
            shuffledColors = ShuffleNames(shuffledColors);
            PrintColors(shuffledColors);
        }
        Console.ResetColor();
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
