    public static void WindowColor(ConsoleColor background, ConsoleColor foreground)
    {
        Console.BackgroundColor = background;
        Console.ForegroundColor = foreground;
        Console.Clear();
    }
    
    static void Main(string[] args)
    {
        WindowColor(ConsoleColor.DarkCyan, ConsoleColor.White);
    }
