    public MainWindow() {
        InitializeComponent();
        DataContext = new MainViewModel();
    }
    public MainViewModel ViewModel => (MainViewModel)DataContext;
    
    private void CopyDelAddress(object sender, RoutedEventArgs e) {
        ViewModel.BillAddress = ViewModel.DelAddress.Clone();
        //  Values ARE NOT copied to BillAddress. A clone of DelAddress 
        //  is assigned to BillAddress.
    }
