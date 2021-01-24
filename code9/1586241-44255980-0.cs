    protected override void OnStart()
    {
        // Handle when your app starts
        OnResume();
    }
    protected override void OnResume()
    {
        // Handle when your app resumes
        Settings.IsConnected = CrossConnectivity.Current.IsConnected;
        CrossConnectivity.Current.ConnectivityChanged += ConnectivityChanged;
    }
    protected override void OnSleep()
    {
        // Handle when your app sleeps
        CrossConnectivity.Current.ConnectivityChanged -= ConnectivityChanged;
    }
    protected async void ConnectivityChanged(object sender, ConnectivityChangedEventArgs e)
    {
        // Save current state and then set it
        var connected = Settings.IsConnected;
        Settings.IsConnected = e.IsConnected;
    
        // If connectivity changes we inform our listeners of that.
        if (connected != e.IsConnected)
            MessagingService.Current.SendMessage(MessageKeys.ConnectivityChanged);
    
        // If we disconnected, show a message for the user that we did.
        if (connected && !e.IsConnected)
        {
            // We went offline, should alert the user and also update ui (done via settings)
            var task = UserDialogs.Instance.AlertAsync("You are offline.", "Connection lost", "OK");
            if (task != null)
                await task;
        }
    }
