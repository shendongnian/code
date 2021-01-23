    internal class WebLoginAuthenticationHandler : AuthenticationHandler<WebLoginAuthenticationOptions>
    {
        protected override async Task<AuthenticationTicket> AuthenticateCoreAsync()
        {
            await Task.Yield();
            var cookie = Context.Request.Cookies[config.CookieName];
            // Return unauthorized if no cookie exists.
            if (cookie == null)
                return null;
            //Check authentication
            // do stuff...
            //User is authenticated - cookie match found 
            var authenticationProperties = CreateAuthenticationProperties(session);
            var identity = CreateIdentity(buildings, session);
            return new AuthenticationTicket(identity, authenticationProperties);
        }
        private static AuthenticationProperties CreateAuthenticationProperties()
        {
            return new AuthenticationProperties
            {
                IssuedUtc = DateTime.UtcNow,
                ExpiresUtc = DateTime.UtcNow.AddHours(12),
                AllowRefresh = true,
                IsPersistent = true
            };
        }
        private ClaimsIdentity CreateIdentity()
        {
            var identity = new ClaimsIdentity(Options.AuthenticationType);
            // add claims
            return identity;
        }
    }
