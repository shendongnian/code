    static void PrintColors(IEnumerable<NamedColor> colors)
    {
        Console.BackgroundColor = ConsoleColor.Gray;
        Console.Write(new string(' ', 80));
        foreach (var color in colors)
        {
            Console.ForegroundColor = color.Color;
            Console.Write(color.Name + " ");
        }
        Console.WriteLine(new string(' ', 139)); // Ugly, hard-coded length for simplicity
    }
