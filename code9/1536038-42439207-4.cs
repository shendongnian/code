    private La _dataContext;
    public MainWindow()
    {
        InitializeComponent();
        _dataContext = new La();
        this.DataContext = _dataContext
    }
    private void Button_Click(object sender, RoutedEventArgs e) 
    {
        _dataContext.AddItem();
    }
