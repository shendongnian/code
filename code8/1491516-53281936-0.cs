    public async override Task OnAuthorizationAsync(HttpActionContext actionContext, CancellationToken cancellationToken)
    {
        IEnumerable<string> values;
        if (actionContext.Request.Headers.TryGetValues("Authentication", out values))
        {
            var token = new Token() { TokenString = values.First() };
            if (await _tg.ValidateToken(token))
            {
                return base.OnAuthorizationAsync(actionContext, cancellationToken);
            }
        }
        await base.HandleUnauthorizedRequest(actionContext);
    }
