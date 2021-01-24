    public override async Task AuthorizeEndpoint(OAuthAuthorizeEndpointContext context)
    {
        if (context.Request.User != null && context.Request.User.Identity.IsAuthenticated)
        {
            var redirectUri = context.Request.Query["redirect_uri"];
            var clientId = context.Request.Query["client_id"];
            var authorizeCodeContext = new AuthenticationTokenCreateContext(
                context.OwinContext, 
                context.Options.AuthorizationCodeFormat,
                new AuthenticationTicket(
                    (ClaimsIdentity)context.Request.User.Identity,
                    new AuthenticationProperties(new Dictionary<string, string>
                    {
                        {"client_id", clientId},
                        {"redirect_uri", redirectUri}
                    })
                {
                    IssuedUtc = DateTimeOffset.UtcNow,
                    ExpiresUtc = DateTimeOffset.UtcNow.Add(context.Options.AuthorizationCodeExpireTimeSpan)
                }));
                
            await context.Options.AuthorizationCodeProvider.CreateAsync(authorizeCodeContext);
            context.Response.Redirect(redirectUri + "?code=" + Uri.EscapeDataString(authorizeCodeContext.Token));
        }
        else
        {
            context.Response.Redirect("/account/login?returnUrl=" + Uri.EscapeDataString(context.Request.Uri.ToString()));
        }
        context.RequestCompleted();
    }
