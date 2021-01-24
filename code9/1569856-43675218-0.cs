    //Button click event for CompactOverlayButton to Create a Frame in CompactOverlay mode
    public async void CompactOverlayButton_ClickAsync(object sender, RoutedEventArgs e)
    {
        //Get current playback position
        var position = mediaPlayerElement.MediaPlayer.PlaybackSession.Position;
        int compactViewId = ApplicationView.GetForCurrentView().Id;      //Initializing compactViewId to the Current View ID
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
        compactOverlayButton.Visibility = Visibility.Collapsed;
    }
