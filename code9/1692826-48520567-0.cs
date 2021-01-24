    static void Main()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.Red;
        Console.Write("Red");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write("Green");
        Console.ForegroundColor = ConsoleColor.Blue;
        Console.WriteLine("Blue");
        Console.ForegroundColor = ConsoleColor.Black;
        Console.BackgroundColor = ConsoleColor.Red;
        Console.Write("Red");
        Console.BackgroundColor = ConsoleColor.Green;
        Console.Write("Green");
        Console.BackgroundColor = ConsoleColor.Blue;
        Console.WriteLine("Blue");
        Console.ResetColor();
        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }
