        public class RequestTrackingMiddleware
        {
            private readonly RequestDelegate next;
            private readonly ILogger logger;
            public RequestTrackingMiddleware(RequestDelegate next, ILogger logger)
            {
                this.next = next;
                this.logger = logger;
            }
            public async Task Invoke(HttpContext context)
            {
                using (logger.BeginScope(new Dictionary<string, object>
                {
                    [SharedProperties.TraceId] =         context.Request.HttpContext.TraceIdentifier,
                }))
                {
                    var stopwatch = Stopwatch.StartNew();
                    bool success = false;
                    try
                    {
                        await next(context);
                        success = true;
                    }
                    catch (System.Exception exception)
                    {
                        logger.LogCritical((int)ServiceFabricEvent.Exception, exception, exception.Message);
                        throw;
                    }
                    finally
                    {
                        stopwatch.Stop();
                        logger.LogRequest(context, stopwatch.Elapsed, success);
                    }
                }
            }
        }
