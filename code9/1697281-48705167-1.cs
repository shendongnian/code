    public static class MethodTimeLogger
    {
        public static void Log(MethodBase methodBase, long milliseconds)
        {
            var sample = new MetricTelemetry();
            sample.Name = methodBase.Name;
            sample.Value = milliseconds;
            // Your telemetryClient here
            telemetryClient.TrackMetric(sample);
        }
    }
