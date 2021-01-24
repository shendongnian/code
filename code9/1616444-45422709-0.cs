    public Task Invoke(HttpContext context)
	{
		
		// If the request path doesn't match, skip
		if (!context.Request.Path.Equals(_options.Path, StringComparison.Ordinal))
		{
			return _next(context);
		}
    }
