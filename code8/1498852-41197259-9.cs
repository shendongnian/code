    public MainPage()
    {
        InitializeComponent();
        DataContext = new ViewModel();
    }
    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        var folderPicker = new Windows.Storage.Pickers.FolderPicker();
        folderPicker.FileTypeFilter.Add(".jpg");
        var folder = await folderPicker.PickSingleFolderAsync();
        await ((ViewModel)DataContext).LoadImages(folder);
    }
