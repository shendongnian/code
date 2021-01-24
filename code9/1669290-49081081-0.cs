        public static class LoggerExtensions
        {
            public static void LogAppError<T>(this ILogger<T> logger, EventId eventId, Exception exception, string message,
                [CallerMemberName] string memberName = "",
                [CallerFilePath] string sourceFilePath = "",
                [CallerLineNumber] int sourceLineNumber = 0)
            {
                using (var prop = LogContext.PushProperty("MemberName", memberName))
                {
                    LogContext.PushProperty("FilePath", sourceFilePath);
                    LogContext.PushProperty("LineNumber", sourceLineNumber);
                    logger.LogError(eventId, exception, message);
                }
            }
    }
