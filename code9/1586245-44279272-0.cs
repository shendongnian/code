      public class TraceSourceExceptionLogger : ExceptionLogger
        {
            private readonly TraceSource _traceSource;
    
            public TraceSourceExceptionLogger(TraceSource traceSource)
            {
                _traceSource = traceSource;
            }
    
            public override void Log(ExceptionLoggerContext context)
            {
                //in this method get the exception details and add it to the sql databse
                _traceSource.TraceEvent(TraceEventType.Error, 1,
                    "Unhandled exception processing {0} for {1}: {2}",
                    context.Request.Method,
                    context.Request.RequestUri,
                    context.Exception);
            }
        }
