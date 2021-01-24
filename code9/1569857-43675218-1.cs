    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is TimeSpan position)
        {
            mediaPlayerElement.MediaPlayer.PlaybackSession.Position = position;
        }
    
        mediaPlayerElement.MediaPlayer.Play();
    }
