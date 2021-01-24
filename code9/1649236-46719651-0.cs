    [OperationContract]
    [WebInvoke(Method = "POST", UriTemplate = "/RestAuthenticateUser/{userID}/{password}/{applicationId}", RequestFormat = WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        authResultDTO RestAuthenticateUser(AuthRequest authRequest);
    
    public authResultDTO AuthenticateUser(string domainName, string userID, string password, string applicationId)
    {
        ...
    }
