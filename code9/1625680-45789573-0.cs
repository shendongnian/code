    public MainPage()
    {
        this.InitializeComponent();
        Window.Current.Dispatcher.AcceleratorKeyActivated += Dispatcher_AcceleratorKeyActivated;
    }
    
    private void Dispatcher_AcceleratorKeyActivated(Windows.UI.Core.CoreDispatcher sender, Windows.UI.Core.AcceleratorKeyEventArgs args)
    {
        var scanCode = args.KeyStatus.ScanCode;
    }
