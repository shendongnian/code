    MediaPlayer mPlayer;
    private  void Button_Click(object sender, RoutedEventArgs e)
    {
        mPlayer = new MediaPlayer();
        mPlayer.Source = MediaSource.CreateFromUri(new System.Uri("ms-appx:///Assets/xxxxx.mp3"));
        mPlayer.MediaOpened += MPlayer_MediaOpened;
        mPlayer.Play();
    }
    
    private void MPlayer_MediaOpened(MediaPlayer sender, object args)
    {
        mPlayer.SystemMediaTransportControls.IsEnabled = false;
    }
