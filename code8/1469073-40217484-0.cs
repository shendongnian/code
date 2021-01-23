    public class ExceptionLogger : IExceptionLogger
    {
        public virtual Task LogAsync(ExceptionLoggerContext context, 
                                 CancellationToken cancellationToken)
       {
        
        return MyLogger.Log(context, cancellationToken);
       }   
    }
