    public static void ErrorAndThrow(this ILogger logger, string message, Exception exception)
    {
        var exceptionInfo = ExceptionDispatchInfo.Capture(exception);
        logger.Error(message);
        exceptionInfo.Throw();
    }
