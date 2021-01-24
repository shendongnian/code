    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        /// set media source
        ...
        /// set media source
        if (e.Parameter is TimeSpan position)
        {
            mediaPlayerElement.MediaPlayer.PlaybackSession.Position = position;
        }
    
        mediaPlayerElement.MediaPlayer.Play();
    }
