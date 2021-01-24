    using System;
    public static class Log
    {
        public static void Write(string message)
        {
            Console.WriteLine($"{DateTime.Now}: {message}");
        }
    }
