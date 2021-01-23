    public root()
    {
        SystemNavigationManager.GetForCurrentView().BackRequested += OnBackRequested;
    }
    
    private void MyFrame_Navigated(object sender, NavigationEventArgs e)
    {
        SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                MyFrame.CanGoBack ?
                AppViewBackButtonVisibility.Visible :
                AppViewBackButtonVisibility.Collapsed;
    }
    
    private void OnBackRequested(object sender, BackRequestedEventArgs e)
    {
        if (MyFrame.CanGoBack)
        {
            e.Handled = true;
            MyFrame.GoBack();
        }
    }
