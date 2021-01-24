    async void OnLoginButtonClicked(object sender, EventArgs e)
    {
        LoadingIndicator.IsVisible = true;
        await Login();
    }
    
    public async Task Login()
    {
        var user = new User
        {
            Email = usernameEntry.Text,
            Password = passwordEntry.Text
        };
    
        User validUser = AreCredentialsCorrect(user);
        if (validUser != null)
        {
            await Navigation.PushAsync(new ProfilePage());
        }
        else
        {
            messageLabel.Text = "Login failed";
            passwordEntry.Text = string.Empty;
            //It will only show the LoadingIndicator at this point.
        }
    }
