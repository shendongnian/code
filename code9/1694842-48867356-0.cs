    public class ExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        private readonly MyLogger _logger;
        private const string ExceptionOccuredLoggingTag = "ExceptionOccured";
        public ExceptionHandlerAttribute(MyLogger logger)
        {
            _logger = logger;
        }
        public override void OnException(HttpActionExecutedContext context)
        {
            ...
            _logger.Error(errorMessage,
                context.Exception,
                mostRecentFrame.Class.Name,
                mostRecentFrame.Method.Name,
                ExceptionOccuredLoggingTag);
            ...
        }
    }
