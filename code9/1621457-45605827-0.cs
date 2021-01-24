        void OnLoginButtonClicked(object sender, EventArgs e)
            {
                LoadingIndicator.IsVisible = true;
                await Login();
            }
            
            public async void Login()
            {
                await Task.Run(() => {
                var user = new User
                {
                    Email = usernameEntry.Text,
                    Password = passwordEntry.Text
                };
            
                 User validUser = AreCredentialsCorrect(user);
                }).ContinueWith((a) => SomeMethod(validUser));
            }
    
             public void SomeMethod()
             {
                Device.BeginInvokeOnMainThread(() =>
                 if (validUser != null)
                 {
                    Navigation.PushAsync(new ProfilePage());
                 }
                 else
                 {
                    messageLabel.Text = "Login failed";
                    passwordEntry.Text = string.Empty;
                    //It will only show the LoadingIndicator at this point.
                 }
               }
             }
