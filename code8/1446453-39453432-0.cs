    public static class Printer
    {
        public static void Warning(string message)
        {
            var currentColor = Console.ForegroundColor;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ForegroundColor = currentColor;
        }
        //Other similar methods here
    }
