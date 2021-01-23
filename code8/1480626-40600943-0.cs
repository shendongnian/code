    AuthenticationContext authenticationContext = new AuthenticationContext(UserModeConstants.AuthString, false);
    string resrouce = "";
    string clientId = "";
    string userName = "";
    string password = "";
    UserPasswordCredential userPasswordCredential = new UserPasswordCredential(userName, password);
    var token= authenticationContext.AcquireTokenAsync(resrouce, clientId, userPasswordCredential).Result.AccessToken;
