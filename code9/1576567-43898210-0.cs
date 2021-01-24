    private void ConsoleWriteColor(ConsoleColor color, string text)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(string.Format(text, prms));
        Console.ResetColor();
    }
    string name1 = "Arthur";
    string name2 = "David";
    ConsoleWriteColor(ConsoleColor.Red, $"Hello {name1} and {name2}");  <-- notice the $
