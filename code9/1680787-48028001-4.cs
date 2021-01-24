    class ConsoleHelper
    {        
        public static void Write(string message, ConsoleColor foreColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void WriteLine(string message, ConsoleColor foreColor, ConsoleColor backColor)
        {
            Write(message + Environment.NewLine, foreColor, backColor);
        }
    }
