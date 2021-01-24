    internal class OAuth2AuthorizationServerProvider : OAuthAuthorizationServerProvider
    {
        public override Task MatchEndpoint(OAuthMatchEndpointContext context)
        {
            if (context.Request.Path.StartsWithSegments(context.Options.AuthorizeEndpointPath)
                && context.Request.QueryString.HasValue)
            {
                context.Request.QueryString = new QueryString(
                    context.Request.QueryString.Value.Replace("%23", "__fragment__"));
            }
            return base.MatchEndpoint(context);
        }
    }
