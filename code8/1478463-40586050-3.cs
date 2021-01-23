        public class MainActivity : Activity, IFacebookCallback
        {
            protected override void OnCreate(Bundle bundle)
            {
                base.OnCreate(bundle);
                // Set our view from the "main" layout resource
                // SetContentView (Resource.Layout.Main);
                var callbackManager = CallbackManagerFactory.Create();
                var loginButton = FindViewById<LoginButton>(Resource.Id.login_button);
                loginButton.RegisterCallback(callbackManager, this);
            }
            #region IFacebookCallback
            public void OnCancel()
            {
                // Handle Cancel
            }
            public void OnError(FacebookException error)
            {
                // Handle Error
            }
            public async void OnSuccess(Object result)
            {
                // We know that this is a LoginResult
                var loginResult = (LoginResult) result;
                // Convert Java.Util.Date to DateTime
                var epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
                var expireDate = epoch.AddMilliseconds(loginResult.AccessToken.Expires.Time);
                // FB User AccessToken
                var accessToken = loginResult.AccessToken.Token;
                ParseUser user = await ParseFacebookUtils.LogInAsync("Your Facebook App Id", accessToken, expireDate);
            }
            #endregion
        ... 
        }
