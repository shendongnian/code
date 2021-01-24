     public async Task Invoke(HttpContext httpContext)
        {
            var requestTelemetry = httpContext.Features.Get<RequestTelemetry>();
            //Handle Request 
            var request = httpContext.Request;
            if (request?.Body?.CanRead == true)
            {
                request.EnableBuffering();
                var bodySize = (int)(request.ContentLength ?? request.Body.Length);
                if (bodySize > 0)
                {
                    request.Body.Position = 0;
                    byte[] body;
                    using (var ms = new MemoryStream(bodySize))
                    {
                        await request.Body.CopyToAsync(ms);
                        body = ms.ToArray();
                    }
                    request.Body.Position = 0;
                    if (requestTelemetry != null)
                    {
                        var requestBodyString = Encoding.UTF8.GetString(body);
                        requestTelemetry.Properties.Add("RequestBody", requestBodyString);
                    }
                }
            }
            await _next(httpContext); // calling next middleware
        }
