    private static void Main()
    {
        Console.Write("If the text is ");
        ConsoleHelper.Write("green", ConsoleColor.Green, ConsoleColor.Black);
        Console.WriteLine(" then it's safe to proceed.");
        Console.Write("\nIf the text is ");
        ConsoleHelper.Write("yellow", ConsoleColor.Yellow, ConsoleColor.Black);
        Console.Write(" or ");
        ConsoleHelper.Write("highlighted yellow", ConsoleColor.White, ConsoleColor.DarkYellow);
        Console.WriteLine(" then proceed with caution.");
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
