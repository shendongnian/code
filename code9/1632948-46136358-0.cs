    protected override void OnCreate(Bundle savedInstanceState)
    {
        // (etc)
        credentials = new CognitoAWSCredentials(
           "us-east-2:00000000-0000-0000-0000-000000000000", // Identity pool ID
           RegionEndpoint.USEast2 // Region
        );
        // (etc)
    }
    private void ShowMessage(string message)
    {
      AlertDialog dlgAlert = new AlertDialog.Builder(this).Create();
      dlgAlert.SetMessage(message);
      dlgAlert.SetButton("Close", (s, args) => { dlgAlert.Dismiss(); });
      dlgAlert.Show();
    }
    public void Logout()
    {
      credentials.Clear();
    }
    public void Login()
    {
      if (!string.IsNullOrEmpty(credentials.GetCachedIdentityId()) || credentials.CurrentLoginProviders.Length > 0)
      {
         if (!bDidLogin)
            ShowMessage(string.Format("I still remember you're {0} ", credentials.GetIdentityId()));
         bDidLogin = true;
         return;
      }
      bDidLogin = true;
      auth = new Xamarin.Auth.OAuth2Authenticator(
         "my-google-client-id.apps.googleusercontent.com",
         string.Empty,
         "openid",
         new System.Uri("https://accounts.google.com/o/oauth2/v2/auth"),
         new System.Uri("com.mynamespace.myapp:/oauth2redirect"),
         new System.Uri("https://www.googleapis.com/oauth2/v4/token"),
         isUsingNativeUI: true);
      auth.Completed += Auth_Completed;
      StartActivity(auth.GetUI(this));
    }
    private void Auth_Completed(object sender, Xamarin.Auth.AuthenticatorCompletedEventArgs e)
    {
      if (e.IsAuthenticated)
      {
         var http = new System.Net.Http.HttpClient();
         var idToken = e.Account.Properties["id_token"];
         credentials.AddLogin("accounts.google.com", idToken);
         AmazonCognitoIdentityClient cli = new AmazonCognitoIdentityClient(credentials, RegionEndpoint.USEast2);
         var req = new Amazon.CognitoIdentity.Model.GetIdRequest();
         req.Logins.Add("accounts.google.com", idToken);
         req.IdentityPoolId = "us-east-2:00000000-0000-0000-0000-000000000000";
         cli.GetIdAsync(req).ContinueWith((task) =>
         {
            if ((task.Status == TaskStatus.RanToCompletion) && (task.Result != null))
               ShowMessage(string.Format("Identity {0} retrieved", task.Result.IdentityId));
            else
               ShowMessage(task.Exception.InnerException!=null ? task.Exception.InnerException.Message : task.Exception.Message);
         });
      }
      else
         ShowMessage("Login cancelled");
    }
