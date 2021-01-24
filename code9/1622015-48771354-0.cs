    private void onLogIn(ILoginResult result)
    {
       if (FB.IsLoggedIn)
       {
          AccessToken tocken = result.AccessToken;//received access token
          userID.text = tocken.UserId;
          Credential credential = FacebookAuthProvider.GetCredential(tocken.TokenString);
          accessToken(credential);//invoke auth method
       }
       else
          Debug.Log("log failed");
    }
