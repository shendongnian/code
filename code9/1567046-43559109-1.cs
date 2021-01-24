    protected async override void OnNavigatingFrom(NavigatingCancelEventArgs e)
    {  
        base.OnNavigatingFrom(e);
        await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,() =>
        {
            YoutubePlayer?.MediaPlayer.Dispose();
        });
    }
