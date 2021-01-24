     public void ConfigureAuth(IAppBuilder app)
            {
               // SignalR Auth0 custom configuration.
                app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions()
                {
                    Provider = new OAuthBearerAuthenticationProvider()
                    {
                        OnRequestToken = context =>
                        {
                            if (context.Request.Path.Value.StartsWith("/signalr"))
                            {
                                string bearerToken = context.Request.Query.Get("token");
                                if (bearerToken != null)
                                {
                                    string[] authorization = new string[] { "bearer " + bearerToken };
                                    context.Request.Headers.Add("Authorization", authorization);
                                }
                            }
    
                            return null;
                        }
                    }
                });
        }
