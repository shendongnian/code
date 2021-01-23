    private void UpdateAppViewBackButton( object sender, NavigationEventArgs e )
    {
        Frame frame = (Frame) sender;
        var systemNavigationManager = SystemNavigationManager.GetForCurrentView();
        systemNavigationManager.AppViewBackButtonVisibility =
            frame.CanGoBack ? AppViewBackButtonVisibility.Visible : 
                              AppViewBackButtonVisibility.Collapsed;
    }
