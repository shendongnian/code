    void OnLoginButtonClicked(object sender, EventArgs e)
    {
        LoadingIndicator.IsVisible = true;
        Login(LoadingIndicator.IsVisible);
    }
    
    public void Login(Bool IsVisible)<--- might have type wrong not familiar with you custom defines types I would expect it to be a bool though.
    IsVisible = true;
    {
        var user = new User
        {
            IsVisible = true;
            Email = usernameEntry.Text,
            Password = passwordEntry.Text
        };
    
        User validUser = AreCredentialsCorrect(user);
        if (validUser != null)
        {
            IsVisible = true;
            Navigation.PushAsync(new ProfilePage());
        }
        else
        {
            IsVisible = true;
            messageLabel.Text = "Login failed";
            passwordEntry.Text = string.Empty;
            //It will only show the LoadingIndicator at this point.
        }
    }
