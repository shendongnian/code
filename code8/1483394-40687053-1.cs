    public MainWindow()
    {
        InitializeComponent();
    }
    protected override void OnClosing(CancelEventArgs e)
    {
        // Without this AppDomain unloading will fail and hate you forever...
        Dispatcher.InvokeShutdown();
        base.OnClosing(e);
    }
