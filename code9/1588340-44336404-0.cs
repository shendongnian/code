        private async Task OnAuthorizationCodeReceived(AuthorizationCodeReceivedContext context)
        {
            // Acquire a Token for the Graph API and cache it using ADAL.  In the TodoListController, we'll use the cache to acquire a token to the Todo List API
            string userObjectId = (context.Ticket.Principal.FindFirst("http://schemas.microsoft.com/identity/claims/objectidentifier"))?.Value;
            ClientCredential clientCred = new ClientCredential(ClientId, ClientSecret);
            AuthenticationContext authContext = new AuthenticationContext(Authority, new NaiveSessionCache(userObjectId, context.HttpContext.Session));
            AuthenticationResult authResult = await authContext.AcquireTokenByAuthorizationCodeAsync(
                context.ProtocolMessage.Code, new Uri(context.Properties.Items[OpenIdConnectDefaults.RedirectUriForCodePropertiesKey]), clientCred, GraphResourceId);
            // Notify the OIDC middleware that we already took care of code redemption.
            context.HandleCodeRedemption();
        }
