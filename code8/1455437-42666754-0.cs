    AuthenticationContext authContext = new AuthenticationContext(Startup.Authority,
                            new NaiveSessionCache(userObjectID));
                        if (authContext.TokenCache.Count == 0)
                        {
                            authContext.TokenCache.Clear();
                            CosmosInterface.Utils.AuthenticationHelper.token = null;
                            HttpContext.GetOwinContext().Authentication.SignOut(
                                OpenIdConnectAuthenticationDefaults.AuthenticationType,
                                CookieAuthenticationDefaults.AuthenticationType);
                        }
