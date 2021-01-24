    while (true)
    {
        // DO NOT INTERCEPT KEY PRESSES! 
        //IF CTRL+S IS FORWARDED TO THE CONSOLE APP, WEIRD THINGS WILL HAPPEN.
        var input = Console.ReadKey(false);
    
        if (input.Modifiers != ConsoleModifiers.Control)
        {
            continue;
        }
    
        if (input.Key == ConsoleKey.S)
        {
            Server?.Dispose();
        }
    }
