    public class DiagnosticObserver : IObserver<KeyValuePair<string, object>>
    {
        private readonly ILogger<DiagnosticObserver> _logger;
        public DiagnosticObserver(ILogger<DiagnosticObserver> logger)
        {
            _logger = logger;
        }
        public void OnCompleted() { }
        public void OnError(Exception error) { }
        public void OnNext(KeyValuePair<string, object> value)
        {
            if (value.Key == "Microsoft.AspNetCore.Hosting.HttpRequestIn.Stop")
            {
                var httpContext = value.Value.GetType().GetProperty("HttpContext")?.GetValue(value.Value) as HttpContext;
                var activity = Activity.Current;
                _logger.LogWarning("Request ended for {RequestPath} in {Duration} ms",
                    httpContext.Request.Path, activity.Duration.TotalMilliseconds);
            }
        }
    }
