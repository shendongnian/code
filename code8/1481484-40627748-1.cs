    // subscribe once
    VideoPlayer.MediaEnded += OnMediaEnded;
    private void OnMediaEnded(object sender, RoutedEventArgs e)
    {
        var nextMediaSource = GetNextMediaSource();
        if(nextMediaSource != null)
            VideoPlayer.SetPlaybackSource(nextMediaSource);
    }
