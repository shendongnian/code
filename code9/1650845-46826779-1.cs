        public static void WriteLog(string message, LogLevel logLevel)
        {
    #if DEBUG
                Console.WriteLine(message);
    #else
                Trace.Write ($"{DateTime.Now:dd.MM.yyyy HH:mm:ss.fff} {message}");
    #endif
        }
