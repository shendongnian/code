    var redirectURI = Windows.Security.Authentication.Web.WebAuthenticationBroker.GetCurrentApplicationCallbackUri();
    var _authContext = new AuthenticationContext(authority);
    var tokenResult = await _authContext.AcquireTokenAsync(serviceResourceId, clientId, redirectURI);
    if (tokenResult.Status != AuthenticationStatus.Success)
    {
        //Not authenticated
        return;
    }
    var svc = new YourServiceReference.YourClient();
    using (var scope = new OperationContextScope(svc.InnerChannel))
    {
        var httpRequestProperty = new HttpRequestMessageProperty();
        httpRequestProperty.Headers[System.Net.HttpRequestHeader.Authorization] = tokenResult.AccessToken;
        OperationContext.Current.OutgoingMessageProperties[HttpRequestMessageProperty.Name] = httpRequestProperty;
        var result = svc.MyFunction();
        //Do something with the data
    }
