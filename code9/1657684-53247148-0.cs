    public async Task Invoke(HttpContext httpContext)
    {
        IServiceProvider serviceProvider = httpContext.RequestServices;
        using (LogContext.Push(new LogEnricher(serviceProvider))) {
            await _next(httpContext);
        }
    }
