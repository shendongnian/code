    ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint
    , new OpenIdConnectConfigurationRetriever()); //need the 'new OpenIdConnect...'
    ...
     TokenValidationParameters validationParameters = new TokenValidationParameters
     {
         ValidateAudience = false,
         ValidateIssuer = false,
         IssuerSigningKeys = config.SigningKeys, //.net core calls it "IssuerSigningKeys" and "SigningKeys"
         ValidateLifetime = false
     };
