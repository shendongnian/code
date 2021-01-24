    public void Configuration(IAppBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=316888
            ConfigureAuth(app);
            
        }
        public void ConfigureAuth(IAppBuilder app)
        {
            app.SetDefaultSignInAsAuthenticationType(DefaultAuthenticationTypes.ApplicationCookie);
            app.UseCookieAuthentication(
            new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie, // application cookie which is generic for all the authentication types.
                LoginPath = new PathString("/login.aspx"), // redirect if not authenticated.
                AuthenticationMode = AuthenticationMode.Passive
            });
            app.UseWsFederationAuthentication(
            new WsFederationAuthenticationOptions
            {
                AuthenticationType = "test auth",
                MetadataAddress = "https://adfs-server/federationmetadata/2007-06/federationmetadata.xml", //adfs meta data.
                Wtrealm = "https://localhost/", //reltying party
                Wreply = "/home.aspx"//redirect
            });
            AuthenticateAllRequests(app, "test auth");
            
        }
        private static void AuthenticateAllRequests(IAppBuilder app, params string[] authenticationTypes)
        {
            app.Use((context, continuation) =>
            {
                if (context.Authentication.User != null &&
                    context.Authentication.User.Identity != null &&
                    context.Authentication.User.Identity.IsAuthenticated)
                {
                    return continuation();
                }
                else
                {
                    context.Authentication.Challenge(authenticationTypes);
                    return Task.Delay(0);
                }
            });
        }
