    string authority = "https://login.microsoftonline.com/adfei.onmicrosoft.com";
    string resrouce = "https://graph.microsoft.com";
    string clientId = "";
    string userName = "";
    string password = "";
    UserPasswordCredential userPasswordCredential = new UserPasswordCredential(userName, password);
    AuthenticationContext authContext = new AuthenticationContext(authority);
    var result = authContext.AcquireTokenAsync(resrouce, clientId, userPasswordCredential).Result;
    var graphserviceClient = new GraphServiceClient(
        new DelegateAuthenticationProvider(
            (requestMessage) =>
            {
                var access_token = authContext.AcquireTokenSilentAsync(resrouce, clientId).Result.AccessToken;
                requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", access_token);
                return Task.FromResult(0);
            }));
    var a = graphserviceClient.Me.Request().GetAsync().Result;
    //simulate the access_token expired to change the access_token
    graphserviceClient.AuthenticationProvider=
         new DelegateAuthenticationProvider(
             (requestMessage) =>
             {
                 var access_token = "abc";
                 requestMessage.Headers.Authorization = new AuthenticationHeaderValue("bearer", access_token);
                 return Task.FromResult(0);
             });
    var b = graphserviceClient.Me.Request().GetAsync().Result;
