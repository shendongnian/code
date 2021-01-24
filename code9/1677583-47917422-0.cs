     public static class TestDocument
        {
            [FunctionName("TestDocument")]
            public static HttpResponseMessage Run([HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)]HttpRequestMessage req, TraceWriter log)
            {
                TelemetryLiveExample telemetryLive = new TelemetryLiveExample
                {
                    Location = new Point(1, 2)
                };
                var json = JsonConvert.SerializeObject(telemetryLive);
    
                return req.CreateResponse(HttpStatusCode.OK, json);
            }
        }
