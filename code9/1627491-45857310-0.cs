    public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //...
            app.UseGoogleAuthentication(new GoogleOptions
            {
                AuthenticationScheme = "Google",
                SignInScheme = "Identity.External", // this is the name of the cookie middleware registered by UseIdentity()
                ClientId = Configuration["ExternalLoginProviders:Google:ClientId"],
                ClientSecret = Configuration["ExternalLoginProviders:Google:ClientSecret"]});
                Scopes = { "profile" };
        }
