    private void SetupButtons()
        {
            Button loginButton = (Button)FindViewById(Resource.Id.signinbtn);
            loginButton.Clicked += delegate { StartActivity(typeof(LoginActivity)); };
            sendToRegisterButton = (Button)FindViewById(Resource.Id.registerbtn);
            sendToRegisterButton.Clicked += delegate { CheckFields(); };
        }
