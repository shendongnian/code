    //Get current playback position
    var position = mediaPlayerElement.MediaPlayer.PlaybackSession.Position;
    int compactViewId = 0;
    await CoreApplication.CreateNewView().Dispatcher.RunAsync(CoreDispatcherPriority.Normal, () =>
    {
        var frame = new Frame();
        compactViewId = ApplicationView.GetForCurrentView().Id;
        frame.Navigate(typeof(VideoPlayerPage), position);
        Window.Current.Content = frame;
        Window.Current.Activate();
        ApplicationView.GetForCurrentView().Title = "";
    });
    bool viewShown = await ApplicationViewSwitcher.TryShowAsViewModeAsync(compactViewId, ApplicationViewMode.CompactOverlay);
