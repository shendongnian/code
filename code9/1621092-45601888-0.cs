    string text = File.ReadAllText(@"..\..\Data\" + FileName + ".txt");
    foreach (char c in text.Replace(" ", ""))
    {
        Console.BackgroundColor = Console.ForegroundColor = (ConsoleColor)(c & 15);
        Console.Write(c);
    }
