     if (context.Request.Method == "POST" || context.Request.Method == "PUT")
            {
                var bodyStr = GetRequestBody(context);
                var telemetryClient = new TelemetryClient();
                var traceTelemetry = new TraceTelemetry
                {
                    Message = bodyStr,
                    SeverityLevel = SeverityLevel.Verbose
                };
                //Send a trace message for display in Diagnostic Search. 
                telemetryClient.TrackTrace(traceTelemetry);
            }
