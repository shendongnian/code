    static void Main()
    {
        // Get the amount of padding needed on the left
        var leftPadding = (Console.WindowWidth - "RedGreenBlue".Length) / 2;
        // Start the cursor at that position
        Console.SetCursorPosition(leftPadding, Console.CursorTop);
        WriteForeColor("Red", ConsoleColor.Red);
        WriteForeColor("Green", ConsoleColor.Green);
        WriteForeColor("Blue\n", ConsoleColor.Blue);
        // Or, pad the left with spaces
        Console.Write(new string(' ', leftPadding));
        WriteColor("Red", ConsoleColor.Black, ConsoleColor.Red);
        WriteBackColor("Green", ConsoleColor.Green);
        WriteBackColor("Blue\n", ConsoleColor.Blue);
        Console.ResetColor();
        Console.Write("\nPress any key to exit...");
        Console.ReadKey();
    }
