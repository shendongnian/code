     app.UseWsFederationAuthentication(new WsFederationAuthenticationOptions
            {
                Wtrealm = realm,
                MetadataAddress = adfsMetadata,
                Notifications = new WsFederationAuthenticationNotifications()
                {
                    // this method will be invoked after login succes 
                    SecurityTokenValidated = notification =>
                    {
                        ClaimsIdentity identity = notification.AuthenticationTicket.Identity;
                        // here we can add claims and specify the type, in my case i want to add Role Claim
                        identity.AddClaim(new Claim(ClaimTypes.Role, "student"));
                        return Task.FromResult(0);
                    },
                    RedirectToIdentityProvider = context =>
                    {
                        context.ProtocolMessage.Wreply = "https://localhost:44329/";
                        return Task.FromResult(0);
                    }
                },
            });
