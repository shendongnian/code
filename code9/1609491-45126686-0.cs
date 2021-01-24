    public MainPage()
    {
        this.InitializeComponent();
        MediaPlayerElementName.MediaPlayer.PlaybackSession.PlaybackStateChanged += PlaybackSession_PlaybackStateChanged;
    }
    bool isFirst = true;
    private void PlaybackSession_PlaybackStateChanged(MediaPlaybackSession sender, object args)
    {
        if (sender.PlaybackState == MediaPlaybackState.Playing)
        {
            if (!isFirst)
            {
                //Set your New source
                isFirst = true;
            }
            else
                isFirst = false;
        }
    }
