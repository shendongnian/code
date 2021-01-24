    TelemetryClient client = new TelemetryClient()
    {
        InstrumentationKey = "{your-Instrumentation-Key}"
    };
    client.TrackRequest(new RequestTelemetry()
    {
        Name = "/api/values",
        StartTime = DateTime.UtcNow,
        Duration = TimeSpan.FromSeconds(2),
        ResponseCode = "200",
        Success = true
    });
