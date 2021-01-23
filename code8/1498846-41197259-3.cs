    public MainPage()
    {
        InitializeComponent();
        DataContext = new ViewModel();
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        await ((ViewModel)DataContext).LoadImages();
    }
