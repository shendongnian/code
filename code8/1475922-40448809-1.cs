    private static MediaPlayer _mediaPlayer = new MediaPlayer();
    
    public static async Task PlayUsingMediaPlayerAsync()
    {
        Windows.Storage.StorageFolder folder = await Windows.ApplicationModel.Package.Current.InstalledLocation.GetFolderAsync(@"Assets");
        Windows.Storage.StorageFile file = await folder.GetFileAsync("Click.wav");
        _mediaPlayer.AutoPlay = false;
        _mediaPlayer.Source = MediaSource.CreateFromStorageFile(file);
                
        _mediaPlayer.MediaOpened += _mediaPlayer_MediaOpened;
               
        _mediaPlayer.IsLoopingEnabled = true;
    
    }
    
    private static void _mediaPlayer_MediaOpened(MediaPlayer sender, object args)
    {
        sender.Play();
    }
