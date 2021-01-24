    public ExceptionHandlingMiddleware(RequestDelegate next)
    {
        _next = next;
    }
    public async Task Invoke(HttpContext context, IEmailRepository emailRepository)
    {
        try
        {
            await _next.Invoke(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex, emailRepository);
        }
    }
