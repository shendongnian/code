     var configManager = new ConfigurationManager<OpenIdConnectConfiguration>(
            stsDiscoveryEndpoint,
            new OpenIdConnectConfigurationRetriever()); //1. need the 'new OpenIdConnect...'
     OpenIdConnectConfiguration config = configManager.GetConfigurationAsync().Result;
     TokenValidationParameters validationParameters = new TokenValidationParameters
     {
         //decode the JWT to see what these values should be
         ValidAudience = "some audience",
         ValidIssuer = "some issuer",
         ValidateAudience = true,
         ValidateIssuer = true,
         IssuerSigningKeys = config.SigningKeys, //2. .NET Core equivalent is "IssuerSigningKeys" and "SigningKeys"
         ValidateLifetime = true
     };
