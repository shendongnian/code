    public class VideoViewModel : ViewModelBase
    {
        
        IDownloader downloader = null;
        public VideoViewModel()
        {
            downloader = DependencyService.Get<IDownloader>();
        }
        private async Task DownloadPdfCommandExecuteAsync(string pdf)
        {
            if (!string.IsNullOrEmpty(pdf))
            {
                Device.BeginInvokeOnMainThread(async () => 
                {
                    if (Device.RuntimePlatform == Device.Android) { DependencyService.Get<IToast>().Show("File downloading..."); await Task.Yield(); }
                });
                await Task.Run(() =>
                {
                    downloader.DownloadFile(pdf, "Antsig");
                });
                if (!isDownloading)
                {
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        DependencyService.Get<IToast>().Show("File Saved Successfully.");
                    });
                }
            }
        }
    }
