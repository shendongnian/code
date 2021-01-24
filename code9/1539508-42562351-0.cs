    class Program
    {
        static void Main(string[] args)
        {
            TelemetryClient tc = new TelemetryClient();
            tc.InstrumentationKey = "fe549116-0099-49fe-a3d6-f36b3dd20860";
            var traceTelemetry = new TraceTelemetry("Console trace critical", SeverityLevel.Critical);
            tc.TrackTrace(traceTelemetry);
            tc.TrackException(new ApplicationException("Test for AI"));
            tc.Flush();
            // Without this line Fiddler didn't show a request
            Thread.Sleep(5000);
        }
    }
