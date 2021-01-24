    public static class AppLog
    {
        public static ILogger Logger = new Logger();
        public static void LogSomething(...)
        {
            Logger.LogSomething(...);
        }
    }
