     MatchEndpoint (OAuthMatchEndpointContext context)
    {
      if ( context.OwinContext.Request.Method == "OPTIONS" && context.IsTokenEndpoint )
       {
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new [] { "*" });
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Methods", new [] { "POST" });
            context.OwinContext.Response.Headers.Add("Access-Control-Allow-Headers", new [] { "accept", "authorisation", "content-type" });
            context.OwinContext.Response.StatusCode = 200;
            context.RequestCompleted();
            return Task.CompletedTask;
       }
    }
