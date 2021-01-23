    public sealed partial class MainPage : Page
        {
            public MainPage()
            {
                this.InitializeComponent();
            }
    
    
            private async void DownloadFile(object sender, RoutedEventArgs e)
            {
                try
                {
                    Uri source = new Uri("http://h.hiphotos.baidu.com/zhidao/pic/item/6d81800a19d8bc3ed69473cb848ba61ea8d34516.jpg");
                    string destination = "dog.jpg";
    
                    StorageFile destinationFile = await KnownFolders.PicturesLibrary.CreateFileAsync(
                        destination, CreationCollisionOption.GenerateUniqueName);
    
                    BackgroundDownloader downloader = new BackgroundDownloader();
                    DownloadOperation download = downloader.CreateDownload(source, destinationFile);
                    await download.StartAsync();
                    // Attach progress and completion handlers.
                    //HandleDownloadAsync(download, true);
                    BackgroundDownloadProgress currentProgress = download.Progress;
    
                    double percent = 100;
                    if (currentProgress.TotalBytesToReceive > 0)
                    {
                        percent = currentProgress.BytesReceived * 100 / currentProgress.TotalBytesToReceive;
                    }
    
                }
               catch (Exception ex)
                {
                   // LogException("Download Error", ex);
                }
            }
        }
