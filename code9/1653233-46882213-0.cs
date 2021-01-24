    public async void OnLogoutButtonClicked(object sender, EventArgs e)
    {
        App.AuthenticationClient.UserTokenCache.Clear(Constants.ApplicationID);
        Application.Current.MainPage = new LoginPage();
    }
