    public MainPage()
    {
        InitializeComponent();
        NavigationCacheMode = Windows.UI.Xaml.Navigation.NavigationCacheMode.Enabled;
    
        if (ApiInformation.IsTypePresent("Windows.UI.ViewManagement.StatusBar"))
        {
            var statusBar = StatusBar.GetForCurrentView();
            if (statusBar != null)
            {
                if (Application.Current.RequestedTheme == ApplicationTheme.Light)
                {
                    statusBar.ForegroundColor = Windows.UI.Colors.Black;
                }
                else if (Application.Current.RequestedTheme == ApplicationTheme.Dark)
                {
                    statusBar.ForegroundColor = Windows.UI.Colors.White;
                }
            }
        }
    }
