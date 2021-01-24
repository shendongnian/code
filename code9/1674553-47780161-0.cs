    namespace Microsoft.UPP.Calc.WebApi.Logging
    {
        public sealed class AiExceptionLogger : ExceptionLogger
        {
            private readonly ITelemetryClient _telemetryClient;
    
            public AiExceptionLogger(ITelemetryClient telemetryClient)
            {
                _telemetryClient = telemetryClient;
            }
    
            public override void Log(ExceptionLoggerContext context)
            {
                LogException(context.Exception);
            }
    
            public void LogException(Exception exception)
            {
                var properties = Enumerable.Zip(exception.Data.Keys.Cast<string>(),
                                                exception.Data.Values.OfType<string>(),
                                                (k, v) => new { Key = k, Value = v })
                                           .Where(x => x.Value != null)
                                           .ToDictionary(x => x.Key, x => x.Value);
                _telemetryClient.TrackException(exception, properties);
            }
    
            public void LogEvent(string eventName, IDictionary<string, string> properties)
            {
                _telemetryClient.TrackEvent(eventName, properties);
            }
        }
    }
