    private ImageSource _videoImageSource;
    public ImageSource VideoImageSource
    {
        get { return _videoImageSource; }
        set 
        { 
            if (true == SetProperty(ref _videoImageSource, value))
            {
                RaisePropertyChanged("VideoImageSource");
            }
        }
    }   
    public void AddVLCPlayer(string videoStreamPath)
    {
        //Create MediaPlayer:
        VlcMediaPlayer = new VlcPlayer(false);
        VlcMediaPlayer.Initialize(Globals.pathLibVlc);
        //Start player
        VlcMediaPlayer.Stop();
        VlcMediaPlayer.LoadMedia(videoStreamPath);
        VlcMediaPlayer.Play();
        //Link VLC player to image source:        
        VideoImageSource = VlcMediaPlayer.VideoSource;
        VlcMediaPlayer.VideoSourceChanged += MediaPlayer_VideoSourceChanged;            
    }
