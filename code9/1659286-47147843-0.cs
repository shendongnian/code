    private static void AuthenticateAllRequests(IAppBuilder app, params string[] authenticationTypes)
                {
                    app.Use((context, continuation) =>
                    {
                        if (context.Authentication.User?.Identity?.IsAuthenticated ?? false)
                        {
                            return continuation();
                        }
                        else
                        {
                            AuthenticationProperties authProps = new AuthenticationProperties
                            {
                                RedirectUri = context.Request.Uri.ToString()
                            };
                            context.Authentication.Challenge(authProps, WsFederationAuthenticationDefaults.AuthenticationType);
                            return Task.CompletedTask;
                        }
                    });
                }
