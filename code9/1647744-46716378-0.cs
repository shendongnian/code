        UserCredential credential = GoogleWebAuthorizationBroker.AuthorizeAsync(new ClientSecrets
    { 
       ClientId = Google.ClientId, ClientSecret = Google.ClientSecret },
       scopes,
       settings.GoogleAccount,
       CancellationToken.None).Result;
    
       // check token is expired
       if (credential.Token.IsExpired(credential.Flow.Clock))
       {
          if (credential.RefreshTokenAsync(CancellationToken.None).Result)
          {
             //The access token is now refreshed. 
          }
          else
          {
             //The access token has expired but we can't refresh it
          }
       }
       else
       {
          //The access token is OK, continue.
       }
    }
