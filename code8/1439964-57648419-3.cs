    public partial class App : Application
    {
	    //Dependencyservice interface
        IDownloader downloader = null;
	    protected override async void OnStart()
        {
            // Handle when your app starts
            downloader = DependencyService.Get<IDownloader>();
            downloader.OnFileDownloaded += OnFileDownloaded;
            base.OnResume();
        }
	    private void OnFileDownloaded(object sender, DownloadEventArgs e)
        {
            if (e.FileSaved)
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    await Application.Current.MainPage.DisplayAlert("File Saved", "The PDF have downloaded.", "OK");
                });
            }
            else
            {
                Device.BeginInvokeOnMainThread(() => { DependencyService.Get<IToast>().Show("Error while saving the file"); });
            }
        }
    }
