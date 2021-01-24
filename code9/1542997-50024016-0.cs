    public class RequestBodyInitializer : ITelemetryInitializer
    {
        readonly IHttpContextAccessor httpContextAccessor;
        public RequestBodyInitializer(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }
        public void Initialize(ITelemetry telemetry)
        {
            if (telemetry is RequestTelemetry requestTelemetry)
            {
                if ((httpContextAccessor.HttpContext.Request.Method == HttpMethods.Post ||
                     httpContextAccessor.HttpContext.Request.Method == HttpMethods.Put) &&
                    httpContextAccessor.HttpContext.Request.Body.CanRead)
                {
                    const string jsonBody = "JsonBody";
                    if (requestTelemetry.Properties.ContainsKey(jsonBody))
                    {
                        return;
                    }
                    //Allows re-usage of the stream
                    httpContextAccessor.HttpContext.Request.EnableRewind();
                    var stream = new StreamReader(httpContextAccessor.HttpContext.Request.Body);
                    var body = stream.ReadToEnd();
                    //Reset the stream so data is not lost
                    httpContextAccessor.HttpContext.Request.Body.Position = 0;
                    requestTelemetry.Properties.Add(jsonBody, body);
                }
            }
        }
