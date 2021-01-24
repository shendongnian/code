    private void VideoPlayer_CurrentStateChanged(object sender, RoutedEventArgs e)
    {
        switch (this.VideoPlayer.CurrentState)
        {
            case MediaElementState.Paused:
    
                break;
    
            case MediaElementState.Playing:
                if (!this.VideoPlayer.AutoPlay)
                {
                    this.VideoPlayer.Source = new Uri("ms-appx:///big_buck_bunny.mp4");
                    this.VideoPlayer.AutoPlay = true;
                }
                break;
        }
    }
    
