    string redirectURI = "uwp.app:/oauth2redirect";
    
    Uri startURI = new Uri(authorizationRequest); // as in the question
    Uri endURI = new Uri(redirectUri); // change to 'redirectUri'
    WebAuthenticationResult webAuthenticationResult = await WebAuthenticationBroker.AuthenticateAsync(WebAuthenticationOptions.None, startURI, endURI);
    switch(webAuthenticationResult.ResponseStatus)
    {
          case WebAuthenticationStatus.Success:
          break;
    }
    
