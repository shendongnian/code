     public class LogExceptionFilter : IExceptionFilter
        {
            public void OnException(ExceptionContext context)
            {
                _log.Error(context.Exception);            
            }
    
            private readonly ILog _log = LogManager.Instance.GetLogger();
        }
