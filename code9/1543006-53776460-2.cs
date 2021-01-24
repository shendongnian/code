    public class PIITelemetryInitializer : ITelemetryInitializer
    {
        IHttpContextAccessor httpContextAccessor;
        public PIITelemetryInitializer(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Initialize(ITelemetry telemetry)
        {
            if (this.httpContextAccessor.HttpContext != null)
            {
                if (telemetry is Microsoft.ApplicationInsights.DataContracts.RequestTelemetry)
                {
                    this.httpContextAccessor.HttpContext.Items.TryAdd("Telemetry", telemetry);
                }
            }
        }
    }
