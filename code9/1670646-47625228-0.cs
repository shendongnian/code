    public async Task Invoke(HttpContext httpContext)
        {
            var timer = Stopwatch.StartNew();
            string bodyAsText = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
            var injectedRequestStream = new MemoryStream();
            var bytesToWrite = Encoding.UTF8.GetBytes(bodyAsText);
            injectedRequestStream.Write(bytesToWrite, 0, bytesToWrite.Length);
            injectedRequestStream.Seek(0, SeekOrigin.Begin);
            httpContext.Request.Body = injectedRequestStream;
            await _next(httpContext);
            
            timer.Stop();
        }
