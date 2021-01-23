    public class ExceptionEnricher : ILogEventEnricher
    {
        public void Enrich(LogEvent logEvent, ILogEventPropertyFactory propertyFactory)
        {
            if (logEvent.Exception != null)
            {
                // do something here
    
                propertyFactory.CreateProperty("ExtraExceptionDetail", extraDetail);
            }
        }
    }
