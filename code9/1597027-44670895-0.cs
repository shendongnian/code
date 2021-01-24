    [Activity(Label = "Activity3", Exported = true)]
    [IntentFilter(new[] { Intent.ActionView },
    DataScheme = "@string/fb_login_protocol_scheme"),]
    public class Activity3 : Activity, IFacebookCallback, IOnCompleteListener
    {
        private ICallbackManager mCallbackManager;
        private FirebaseAuth mAuth;
    
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
    
            FacebookSdk.SdkInitialize(this.ApplicationContext);
            // Create your application here
            SetContentView(Resource.Layout.layout3);
    
            FirebaseApp.InitializeApp(this);
            mAuth = FirebaseAuth.Instance;
    
            LoginButton fblogin = FindViewById<LoginButton>(Resource.Id.fblogin);
            fblogin.SetReadPermissions("email", "public_profile");
    
            mCallbackManager = CallbackManagerFactory.Create();
            fblogin.RegisterCallback(mCallbackManager, this);
        }
    
        private void handleFacebookAccessToken(AccessToken accessToken)
        {
            AuthCredential credential = FacebookAuthProvider.GetCredential(accessToken.Token);
            mAuth.SignInWithCredential(credential).AddOnCompleteListener(this, this);
        }
    
        //facebook IFacebookCallback implementation
        public void OnSuccess(Java.Lang.Object p0)
        {
            LoginResult loginResult = p0 as LoginResult;
            handleFacebookAccessToken(loginResult.AccessToken);
        }
    
        public void OnCancel()
        {
        }
    
        public void OnError(FacebookException p0)
        {
        }
    
        //firebase IOnCompleteListener implementation
        public void OnComplete(Task task)
        {
            if (task.IsSuccessful)
            {
                FirebaseUser user = mAuth.CurrentUser;
            }
            else
            {
                Toast.MakeText(this, "Authentication failed.", ToastLength.Short).Show();
            }
        }
    
        // acitivity lifecycle
        protected override void OnStart()
        {
            base.OnStart();
            FirebaseUser currentUser = mAuth.CurrentUser;
        }
    
        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            var resultCodeNum = 0;
            switch (resultCode)
            {
                case Result.Ok:
                    resultCodeNum = -1;
                    break;
    
                case Result.Canceled:
                    resultCodeNum = 0;
                    break;
    
                case Result.FirstUser:
                    resultCodeNum = 1;
                    break;
            }
            mCallbackManager.OnActivityResult(requestCode, resultCodeNum, data);
        }
    }
