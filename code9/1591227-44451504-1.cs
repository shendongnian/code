    //TelemetryClient telemetryClient = new Microsoft.ApplicationInsights.TelemetryClient();
    ...
    telemetryClient.TrackEvent("<EventName>");
    telemetryClient.TrackMetric("<metric name>", 1);
    telemetryClient.TrackTrace("message", SeverityLevel.Information);
