    protected override void OnLaunched(LaunchActivatedEventArgs e)
    {
        ……
        frame.OnNavigated += Frame_Navigated;
        ……
    }
    
    private void Frame_Navigated(object sender, NavigationEventArgs e)
    {
        var frame = Window.Current.Content as Frame;
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility = frame.CanGoBack ?
                      AppViewBackButtonVisibility.Visible :
                      AppViewBackButtonVisibility.Collapsed;
    }
