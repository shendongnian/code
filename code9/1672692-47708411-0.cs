    private async void Page_Loaded(object sender, RoutedEventArgs e)
    {
        IReadOnlyList<User> users = await User.FindAllAsync();
    
        var current = users.Where(p => p.AuthenticationStatus == UserAuthenticationStatus.LocallyAuthenticated && 
                                    p.Type == UserType.LocalUser).FirstOrDefault();
    
        // user may have username
        var data = await current.GetPropertyAsync(KnownUserProperties.AccountName);
        string displayName = (string)data;
      
        text1.Text = displayName;
    }
