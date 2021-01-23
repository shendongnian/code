            app.Map("/admin", adminApp =>
            {
                var factory = new IdentityAdminServiceFactory();
                factory.Configure();
                adminApp.UseCookieAuthentication(new CookieAuthenticationOptions
                {
                    AuthenticationType = "Cookies"
                });
                adminApp.UseWsFederationAuthentication(new WsFederationAuthenticationOptions
                {
                    MetadataAddress = ConfigurationManager.AppSettings["AzureADMetadataEndpoint"],
                    Wtrealm = ConfigurationManager.AppSettings["AzureADApplicationId"],
                    SignInAsAuthenticationType = "Cookies",
                    Notifications = new WsFederationAuthenticationNotifications
                    {
                        SecurityTokenValidated = ctx =>
                        {
                            var roleClaim = new Claim("role", "IdentityManagerAdministrator");
                            ctx.AuthenticationTicket.Identity.AddClaim(roleClaim);
                            return Task.FromResult(0);
                        }
                    }
                });
                adminApp.UseIdentityAdmin(new IdentityAdminOptions
                {
                    Factory = factory,
                    AdminSecurityConfiguration = new AdminHostSecurityConfiguration
                    {
                        HostAuthenticationType = "Cookies",
                        NameClaimType = ClaimTypes.Name,
                        RoleClaimType = "role",
                        AdminRoleName = "IdentityManagerAdministrator"
                    }
                });
            });
