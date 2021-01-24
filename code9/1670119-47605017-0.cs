    public async Task AuthenticateAsync(HttpAuthenticationContext context, CancellationToken cancellationToken)
    {
    	Trace.TraceInformation("Authenticate");
    
    	context.ErrorResult = new UnauthorizedResult(Enumerable.Empty<AuthenticationHeaderValue>(), context.Request);
    }
