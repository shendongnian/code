    ConfigurationManager<OpenIdConnectConfiguration> configManager = new ConfigurationManager<OpenIdConnectConfiguration>(stsDiscoveryEndpoint
    , new OpenIdConnectConfigurationRetriever()); //need the 'new OpenIdConnect...'
    ...
     TokenValidationParameters validationParameters = new TokenValidationParameters
     {
         //decode the JWT to see what these values should be
         ValidAudience = "some audience",
         ValidIssuer = "some issuer",
         ValidateAudience = true,
         ValidateIssuer = true,
         IssuerSigningKeys = config.SigningKeys, //.net core calls it "IssuerSigningKeys" and "SigningKeys"
         ValidateLifetime = true
     };
