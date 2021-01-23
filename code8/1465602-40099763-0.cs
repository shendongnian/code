    public MainPage()
    {
        InitializeComponent();
        var ignored = Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow
            .Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () => TryInitAsync());
    }
