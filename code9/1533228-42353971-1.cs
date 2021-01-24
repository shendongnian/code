    public static string CustomReadLine()
    {
        ConsoleKeyInfo cki;
        string value = string.Empty;
        do
        {
            cki = Console.ReadKey();
            value = value + cki.Key;
        } while (cki.Key != ConsoleKey.Enter);
        return value;
    }
