    class Authenticator : IAuthenticator
    {
        public async Task<AuthenticationResult> AuthenticateAsync(UserLogOn user, string authority, string resource, Uri redirectURI, string clientId)
        {
            try
            {
                var authContext = new AuthenticationContext(authority);
                var authResult = await authContext.AcquireTokenAsync(resource, clientId, redirectURI,
                    new PlatformParameters(UIApplication.SharedApplication.KeyWindow.RootViewController));
                return authResult;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
