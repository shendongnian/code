    public static class LogHelper
    {
        [Conditional("DEBUG")]
        public static void LogDebug(this ILogger logger, string message, params object[] args)
        {
            LoggerExtensions.LogDebug(logger, message, args);
        }
    }
