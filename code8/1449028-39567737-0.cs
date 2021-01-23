    public SplitShellPage(Frame frame)
    {
        this.InitializeComponent();
        NavigationCacheMode = NavigationCacheMode.Enabled;
        shell_splitview.Content = frame;
        (shell_splitview.Content as Frame).Navigate(typeof(MainPage));
        SystemNavigationManager.GetForCurrentView().BackRequested += SplitShellPage_BackRequested;
    }
    private void SplitShellPage_BackRequested(object sender, BackRequestedEventArgs e)
    {
        Frame myFrame = shell_splitview.Content as Frame;
        if (myFrame.CanGoBack)
        {
            e.Handled = true;
            myFrame.GoBack();
        }
    }
