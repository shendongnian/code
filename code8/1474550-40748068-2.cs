    public void Configuration(IAppBuilder app)
    {
        var issuer = $"[url to identity provider]/";
        var audience = "[your API id];
        app.UseActiveDirectoryFederationServicesBearerAuthentication(
            new ActiveDirectoryFederationServicesBearerAuthenticationOptions
            {
                TokenValidationParameters = new TokenValidationParameters
                {
                    ValidAudience = audience,
                    ValidIssuer = issuer
                    // you will also have to configure the keys/certificates
                }
            });
