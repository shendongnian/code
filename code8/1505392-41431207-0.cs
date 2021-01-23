                   Notifications = new OpenIdConnectAuthenticationNotifications()
                    {
                        RedirectToIdentityProvider = (context) =>
                        {
                            context.ProtocolMessage.RedirectUri = HttpContext.Current.Request.Url.GetLeftPart(System.UriPartial.Path);
                            context.ProtocolMessage.PostLogoutRedirectUri = new UrlHelper(HttpContext.Current.Request.RequestContext).Action("Index", "Home", null, HttpContext.Current.Request.Url.Scheme);
                            context.ProtocolMessage.Resource = GraphAPIIdentifier;                            
                            return Task.FromResult(0);
                        }}
