    public class RequestBodyInitializer : ITelemetryInitializer
    {
        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry is RequestTelemetry)
            {
                RequestTelemetry requestTelemetry = (RequestTelemetry)telemetry;
                using (var reader = new StreamReader(HttpContext.Current.Request.InputStream))
                {
                    string requestBody = reader.ReadToEnd();
                    requestTelemetry.Properties.Add("body", requestBody);
                }
            }
        }
    }
