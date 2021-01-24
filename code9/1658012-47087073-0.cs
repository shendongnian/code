       public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
 
            string clientId = string.Empty;
            string clientSecret = string.Empty;
            Client client = null;
 
            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }
 
            if (context.ClientId == null)
            {
                //Remove the comments from the below line context.SetError, and invalidate context 
                //if you want to force sending clientId/secrects once obtain access tokens. 
                context.Validated();
                //context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }
 
            using (AuthRepository _repo = new AuthRepository())
            {
                client = _repo.FindClient(context.ClientId);
            }
 
            if (client == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }
 
            if (client.ApplicationType == Models.ApplicationTypes.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (client.Secret != Helper.GetHash(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret is invalid.");
                        return Task.FromResult<object>(null);
                    }
                }
            }
 
            if (!client.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }
 
            context.OwinContext.Set<string>("as:clientAllowedOrigin", client.AllowedOrigin);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", client.RefreshTokenLifeTime.ToString());
 
            context.Validated();
            return Task.FromResult<object>(null);
        }
