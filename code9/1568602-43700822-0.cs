    Windows.Media.Playback.MediaPlayer mp;
    public void CreatePlayer()
    {
      Windows.Media.Core.MediaBinder mb = new Windows.Media.Core.MediaBinder();
      mb.Binding += Mb_Binding;           
      var ms = Windows.Media.Core.MediaSource.CreateFromMediaBinder(mb);
      mp = new Windows.Media.Playback.MediaPlayer();
      mp.CommandManager.IsEnabled = false;
      mp.Source = ms;
    }
    
    private void Mb_Binding(Windows.Media.Core.MediaBinder sender, Windows.Media.Core.MediaBindingEventArgs args)
    {
      var d = args.GetDeferral();
    }
