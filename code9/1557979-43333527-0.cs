    var aad = new OpenIdConnectAuthenticationOptions
                {
                    AuthenticationType = "AzureAd",
                    Caption = "Marquis Azure AD",
                    SignInAsAuthenticationType = signInAsType,
                    PostLogoutRedirectUri = Settings.LogoutRedirect,
                    Authority = Settings.AADAuthority,
                    ClientId = Settings.AADClientId,
                    RedirectUri = Settings.AADRedirectUrl,
                    ConfigurationManager = manager
                };
