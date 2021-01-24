    public class MessageTracingHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            // Trace the request
            await TraceRequest(request);
            // Execute the request
            var response = await base.SendAsync(request, cancellationToken);
            // Trace the response
            await TraceResponse(response);
            return response;
        }
        private async Task TraceRequest(HttpRequestMessage request)
        {
            try
            {
                var requestTelemetry = HttpContext.Current?.GetRequestTelemetry();
                var requestTraceInfo = request.Content != null ? await request.Content.ReadAsByteArrayAsync() : null;
                var body = requestTraceInfo.ToString();
                if (!string.IsNullOrWhiteSpace(body) && requestTelemetry != null)
                {
                    requestTelemetry.Properties.Add("Request Body", body);
                }
            }
            catch (Exception exception)
            {
                // Log exception
            }
        }
        private async Task TraceResponse(HttpResponseMessage response)
        {
            try
            {
                var requestTelemetry = HttpContext.Current?.GetRequestTelemetry();
                var responseTraceInfo = response.Content != null ? await response.Content.ReadAsByteArrayAsync() : null;
                var body = responseTraceInfo.ToString();
                if (!string.IsNullOrWhiteSpace(body) && requestTelemetry != null)
                {
                    requestTelemetry.Properties.Add("Response Body", body); 
                }
            }
            catch (Exception exception)
            {
                // Log exception
            }
        }
    }
