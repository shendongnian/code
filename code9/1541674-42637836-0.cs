    public ReadResult Read()
    {
        var temp = Console.ReadKey(true);
        return new ReadResult(temp.KeyChar, temp.Key == ConsoleKey.Escape);
    }
