    long token;
    
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        token = mediaPlayer.RegisterPropertyChangedCallback(MediaPlayerElement.IsFullWindowProperty, OnMediaPlayerFullWindowChanged);
        base.OnNavigatedTo(e);
    }
    
    protected override void OnNavigatedFrom(NavigationEventArgs e)
    {
        mediaPlayer.UnregisterPropertyChangedCallback(MediaPlayerElement.IsFullWindowProperty, token);
    }
