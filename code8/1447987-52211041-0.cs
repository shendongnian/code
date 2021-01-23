            var options = new OAuthAuthorizationServerOptions();
            var ticket = new AuthenticationTicket(...);
            
            var tokenContext = new AuthenticationTokenCreateContext(null, options.AccessTokenFormat, ticket);
            await context.options.AccessTokenProvider.CreateAsync(tokenContext);
            var token = tokenContext.Token;
            if (string.IsNullOrEmpty(token)) token = tokenContext.SerializeTicket();
            return token;
