    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.CoreWindow.SizeChanged += CoreWindow_SizeChanged;
    }
    
    private void CoreWindow_SizeChanged(Windows.UI.Core.CoreWindow sender, Windows.UI.Core.WindowSizeChangedEventArgs args)
    {
        var appView = Windows.UI.ViewManagement.ApplicationView.GetForCurrentView();
        if (!appView.IsFullScreen)
        {
            appView.TryEnterFullScreenMode();
        }
        args.Handled = true;
    }
