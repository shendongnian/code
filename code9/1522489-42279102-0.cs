    async void OnLoginButtonClicked(object sender, EventArgs e    ) {
    
        try {
            var token = await GetAPIToken(usernameEntry.Text, passwordEntry.Text, "http://192.168.0.185");
        } catch (Exception ex) {
    
        }
    
        App.IsUserLoggedIn = true;
        Navigation.InsertPageBefore(new MainPage(), this);
        await Navigation.PopAsync();
    }
