    PublicClientApplication publicClientApplication = new PublicClientApplication(AuthParameters.Authority, AuthParameters.ClientId);
    var authResult = await publicClientApplication.AcquireTokenSilentAsync(AuthParameters.Scopes, "", AuthParameters.Authority, AuthParameters.Policy, false);
    //      await Navigation.PushAsync(new SecurePage());
    var result = authResult.Token;
                
                textbox.Text = authResult.User.Name;
