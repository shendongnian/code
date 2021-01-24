    public async Task Invoke(HttpContext context)
        {  
            StringValues sessionId;
            var session = string.Empty;
            if (context.Request.Headers.TryGetValue("X-SessionID", out sessionId))
            {
                session = sessionId.FirstOrDefault();
                if (session != null) 
                {
                    var requestBodyStream = new MemoryStream();
                    var originalRequestBody = context.Request.Body;
                    await context.Request.Body.CopyToAsync(requestBodyStream);
                    requestBodyStream.Seek(0, SeekOrigin.Begin);
                    var url = UriHelper.GetDisplayUrl(context.Request);
                    var requestBodyText = new StreamReader(requestBodyStream).ReadToEnd();
                    _logger.LogInformation($"{session} {context.Request.Method} {url} {requestBodyText}");
                    requestBodyStream.Seek(0, SeekOrigin.Begin);
                    context.Request.Body = requestBodyStream;
                    await _next.Invoke(context);
                    context.Request.Body = originalRequestBody;
                }
            } else {
                await _next.Invoke(context);
            }
        }
