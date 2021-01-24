    private void ConsoleWriteColor(ConsoleColor color, string text, params object[] prms)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(string.Format(text, prms));
        Console.ResetColor();
    }
