        static void WriteBackColor(string text, ConsoleColor backColor)
        {
            Console.BackgroundColor = backColor;
            Console.Write(text);
        }
        static void WriteForeColor(string text, ConsoleColor foreColor)
        {
            Console.ForegroundColor = foreColor;
            Console.Write(text);
        }
        static void WriteColor(string text, ConsoleColor foreColor, ConsoleColor backColor)
        {
            Console.ForegroundColor = foreColor;
            Console.BackgroundColor = backColor;
            Console.Write(text);
        }
