    public Task Invoke(HttpContext context, IAccountService accountService)
    {
        // If the request path doesn't match, skip
        if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
        {
            return _next(context);
        }
        if (!context.Request.Method.Equals("POST")
           || !context.Request.ContentType.Contains("application/json"))
        {
            context.Response.StatusCode = 400;
            return context.Response.WriteAsync("Bad request.");
        }
        return GenerateToken(context, accountService);
    }
