    private const string StartTimestampKey = "DiagnosticObserver_StartTimestamp";
    public void OnNext(KeyValuePair<string, object> value)
    {
        if (value.Key == "Microsoft.AspNetCore.Hosting.BeginRequest")
        {
            var httpContext = (HttpContext)value.Value.GetType().GetProperty("httpContext").GetValue(value.Value);
            httpContext.Items[StartTimestampKey] = (long)value.Value.GetType().GetProperty("timestamp").GetValue(value.Value);
        }
        else if (value.Key == "Microsoft.AspNetCore.Hosting.EndRequest")
        {
            var httpContext = (HttpContext)value.Value.GetType().GetProperty("httpContext").GetValue(value.Value);
            var endTimestamp = (long)value.Value.GetType().GetProperty("timestamp").GetValue(value.Value);
            var startTimestamp = (long)httpContext.Items[StartTimestampKey];
            var duration = new TimeSpan((long)((endTimestamp - startTimestamp) * TimeSpan.TicksPerSecond / (double)Stopwatch.Frequency));
            _logger.LogWarning("Request ended for {RequestPath} in {Duration} ms",
                httpContext.Request.Path, duration.TotalMilliseconds);
        }
    }
