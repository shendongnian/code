    int inputBoundary = Console.CursorLeft;
    string consoleInput = String.Empty;
    ConsoleKeyInfo inputKey;
    while((inputKey = Console.ReadKey(true)).Key != ConsoleKey.Enter || consoleInput == String.Empty)
    {
        if (inputKey.Key == ConsoleKey.Backspace && Console.CursorLeft != inputBoundary)
        {
            Console.Write("\b \b");
            consoleInput = consoleInput.Remove(consoleInput.Length - 1);
            continue;
        }
        if (Char.IsNumber(inputKey.KeyChar))
        {
            Console.Write(inputKey.KeyChar);
            consoleInput += inputKey.KeyChar;
        }
    }
    int selection = Int32.Parse(consoleInput);
