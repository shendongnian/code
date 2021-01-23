    public static void WindowColor(string Background, string Foreground)
    {
        Console.BackgroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), Background, true);
        Console.ForegroundColor = (ConsoleColor) Enum.Parse(typeof(ConsoleColor), Foreground, true);
        Console.Clear();
    }
    
    static void Main(string[] args)
    {
        WindowColor("DarkCyan","White");
    }
