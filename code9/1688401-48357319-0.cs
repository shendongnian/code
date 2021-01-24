    foreach (var i in Enumerable.Range(0, Console.BufferHeight + 3))
    {
        var fgColor = Console.ForegroundColor;
        var bgColor = Console.BackgroundColor;
        var tst = i % 2 == 0;
        Console.ForegroundColor = tst ? ConsoleColor.White : ConsoleColor.Black;
        Console.BackgroundColor = tst ? ConsoleColor.Black : ConsoleColor.Yellow;
        Console.Write($"{i} HELLO WORLD");
        Console.ForegroundColor = fgColor;
        Console.BackgroundColor = bgColor;
        Console.WriteLine();
    }
