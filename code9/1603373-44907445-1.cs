    private static string RewriteToPublicOrigin(string originalUrl)
    {
        var publicOrigin = ConfigurationManager.AppSettings["app:identityServer.PublicOrigin"];
        if (!string.IsNullOrEmpty(publicOrigin))
        {
            var uriBuilder = new UriBuilder(originalUrl);
            var publicOriginUri = new Uri(publicOrigin);
            uriBuilder.Host = publicOriginUri.Host;
            uriBuilder.Scheme = publicOriginUri.Scheme;
            uriBuilder.Port = publicOriginUri.Port;
            var newUrl = uriBuilder.Uri.AbsoluteUri;
         
            return newUrl;
        }
    
        return originalUrl;
    }
