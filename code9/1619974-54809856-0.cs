    public static class LoggerTestingExtensions
    {
        public static void LogError(this ILogger logger, string message)
        {
            logger.Log(
                LogLevel.Error,
                0,
                Arg.Is<FormattedLogValues>(v => v.ToString() == message),
                Arg.Any<Exception>(),
                Arg.Any<Func<object, Exception, string>>());
        }
    
    }
