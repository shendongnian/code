    IConfigurationManager<OpenIdConnectConfiguration> configurationManager = new ConfigurationManager<OpenIdConnectConfiguration>($"{auth0Domain}.well-known/openid-configuration", new OpenIdConnectConfigurationRetriever());
    OpenIdConnectConfiguration openIdConfig = await configurationManager.GetConfigurationAsync(CancellationToken.None);
    TokenValidationParameters validationParameters =
        new TokenValidationParameters
        {
            ValidIssuer = auth0Domain,
            ValidAudiences = new[] { auth0Audience },
            IssuerSigningKeys = openIdConfig.SigningKeys
        };
    SecurityToken validatedToken;
    JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
    var user = handler.ValidateToken("eyJhbGciOi.....", validationParameters, out validatedToken);
