    public MainPage()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
        list.Items.Clear();
        var files = await KnownFolders.PicturesLibrary.GetFilesAsync();
        foreach (var file in files)
        {
            var bitmap = new BitmapImage();
            using (var stream = await file.OpenReadAsync())
            {
                await bitmap.SetSourceAsync(stream);
            }
            list.Items.Add(bitmap);
        }
    }
