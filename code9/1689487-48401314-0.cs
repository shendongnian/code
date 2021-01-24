    while (true)
    {
        var input = Console.ReadKey(true);
    
        if (input.Modifiers != ConsoleModifiers.Control)
        {
            continue;
        }
    
        if (input.Key == ConsoleKey.S)
        {
            Server?.Dispose();
        }
    }
