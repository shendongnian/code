    public MainPage()
    {
        this.InitializeComponent();
        this.Loaded += LoadedHandler;
    }
    private async void LoadedHandler(object sender, RoutedEventArgs e)
    {
        // assume that we want to do this only once
        this.Loaded -= LoadedHandler;
        await OpenFile();
        await SaveFile();
    }
    public async Task OpenFile()
    {
        FileOpenPicker picker = new FileOpenPicker();
        picker.SuggestedStartLocation = PickerLocationId.Desktop;
        picker.FileTypeFilter.Add(".txt");
        DataFile = await picker.PickSingleFileAsync();
        if (DataFile == null) { return; }
    }
    public async Task SaveFile()
    {
        await FileIO.AppendTextAsync(DataFile, "" + DateTime.Now + "\n");
    }
    private StorageFile DataFile { get; set; }
