    public MainPage()
    {
        InitializeComponent();
        DataContext = new ViewModel();
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        ...
        var folder = ...
        await ((ViewModel)DataContext).LoadImages(folder);
    }
