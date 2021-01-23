    string aadTenant = WebServiceClientConfiguration.Settings.ActiveDirectoryTenant;
    string clientAppId = WebServiceClientConfiguration.Settings.ClientAppId;
    string clientKey = WebServiceClientConfiguration.Settings.ClientKey;
    string aadResource = WebServiceClientConfiguration.Settings.ActiveDirectoryResource;
    
    AuthenticationContext authenticationContext = new AuthenticationContext(aadTenant);
    ClientCredential clientCredential = new ClientCredential(clientAppId, clientKey);
    UserPasswordCredential upc = new UserPasswordCredential(WebServiceClientConfiguration.Settings.UserName, WebServiceClientConfiguration.Settings.Password);
    
    AuthenticationResult authenticationResult = await authenticationContext.AcquireTokenAsync(aadResource, clientAppId, upc);
    
    return authenticationResult.CreateAuthorizationHeader();
