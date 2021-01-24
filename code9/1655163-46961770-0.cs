    ConsoleKey key;
    do
    {
        while (!Console.KeyAvailable)
        {
            // Do something, but don't read key here
        }
        // Key is available - read it
        var keyInfo = Console.ReadKey(true);
        key = keyInfo.Key;
        if ((keyInfo.Modifiers & ConsoleModifiers.Control) != 0)
        {
            Console.Write("Ctrl + ");
        }
        if (key == ConsoleKey.NumPad1)
        {                    
            Console.WriteLine(ConsoleKey.NumPad1.ToString());
        }
        else if (key == ConsoleKey.NumPad2)
        {
            Console.WriteLine(ConsoleKey.NumPad2.ToString());
        }
    } while (key != ConsoleKey.Escape);
