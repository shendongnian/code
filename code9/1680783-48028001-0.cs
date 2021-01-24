    class ConsoleHelper
    {
        const ConsoleColor defaultForeColor = ConsoleColor.White;
        const ConsoleColor defaultBackColor = ConsoleColor.Black;
        public static void Write(string message, ConsoleColor foreColor = defaultForeColor, 
            ConsoleColor backColor = defaultBackColor)
        {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
            Console.Write(message);
            Console.ResetColor();
        }
        public static void WriteLine(string message, ConsoleColor foreColor = defaultForeColor,
            ConsoleColor backColor = defaultBackColor)
        {
            Write(message + Environment.NewLine, foreColor, backColor);
        }
    }
