    static void Main()
    {
        WriteForeColor("Red", ConsoleColor.Red);
        WriteForeColor("Green", ConsoleColor.Green);
        WriteForeColor("Blue\n", ConsoleColor.Blue);
        WriteColor("Red", ConsoleColor.Black, ConsoleColor.Red);
        WriteBackColor("Green", ConsoleColor.Green);
        WriteBackColor("Blue\n", ConsoleColor.Blue);
        Console.ResetColor();
        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }
