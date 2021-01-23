    var ai = new TelemetryClient();
    ai.InstrumentationKey = "<your instrumentation key from azure>";
    ai.TrackTrace("Hello! " + DateTime.Now.ToString());
    ai.TrackTrace("Info " + DateTime.Now.ToString(), SeverityLevel.Information, 
         // Here you can add a structure into the log
         new Dictionary<string, object>() { { "UserId", activity.GetChannelData<object>()}}
    );
    ai.Flush(); // it sends the logs into the telemetry service
