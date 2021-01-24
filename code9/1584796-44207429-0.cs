        public MainPage()
        {
            this.InitializeComponent();
        }
        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            Debug.WriteLine("Download started");
            var file = await DownloadAsync();
            Debug.WriteLine("Download finished");
            player.Source = MediaSource.CreateFromStorageFile(file);
            player.Play();
        }
        private async Task<StorageFile> DownloadAsync()
        {
            StorageFile destinationFile = await ApplicationData.Current.LocalFolder.CreateFileAsync(
                "data.mp3", CreationCollisionOption.GenerateUniqueName);
            BackgroundDownloader downloader = new BackgroundDownloader();
            DownloadOperation download = downloader.CreateDownload(new Uri(url), destinationFile);
            await download.StartAsync().AsTask();
            return destinationFile;
        }
