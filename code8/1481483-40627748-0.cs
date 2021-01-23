    // subscribe once
    VideoPlayer.MediaEnded += OnMediaEnded;
    private void OnMediaEnded(...)
    {
        var nextMediaSource = GetNextMediaSource();
        VideoPlayer.SetPlaybackSource(nextMediaSource);
    }
