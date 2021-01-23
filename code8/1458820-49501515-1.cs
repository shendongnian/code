    ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint
    , new OpenIdConnectConfigurationRetriever()); //need the 'new OpenIdConnect...'
    ...
     TokenValidationParameters validationParameters = new TokenValidationParameters
     {
         ValidateAudience = true,
         ValidateIssuer = true,
         IssuerSigningKeys = config.SigningKeys, //.net core calls it "IssuerSigningKeys" and "SigningKeys"
         ValidateLifetime = true
     };
