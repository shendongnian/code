    public static void Main(string[] args)
    {
        //Your code goes here
        Console.WriteLine("Hello, world!");
        ConsoleWriteColor(ConsoleColor.Red,"Hello {0} and {1}","Arthur","David")
    }
    
    private static void ConsoleWriteColor(ConsoleColor color, string text,params object[] a)
    {
        Console.ForegroundColor = color;
        Console.WriteLine(string.Format(text,a));
        Console.ResetColor();
    }
