    public MainPage()
    {
        this.InitializeComponent();
        this.DataContext = new MainViewModel();
        this.Loaded += MainPage_Loaded;
    }
    private void MainPage_Loaded(object sender, RoutedEventArgs e)
    {
        MainViewModel mvm = this.DataContext as MainViewModel;
        mvm.VsmConnectionStatus = "Connected";
    }
