    public MainWindow()
    {
        InitializeComponent();
        cb_MCUType.ItemsSource = App.ProductDb.GetProducts().Select(p => p.McuName);
    }
