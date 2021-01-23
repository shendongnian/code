    private void CoreWindow_KeyDown(CoreWindow sender, KeyEventArgs args)
    {
        if (args.VirtualKey == Windows.System.VirtualKey.Space && !Player.IsFullWindow)
        {
            if (Player.MediaPlayer.PlaybackSession.PlaybackState == Windows.Media.Playback.MediaPlaybackState.Playing)
            {
                Player.MediaPlayer.Pause();
            }
            else if (Player.MediaPlayer.PlaybackSession.PlaybackState == Windows.Media.Playback.MediaPlaybackState.Paused)
            {
                Player.MediaPlayer.Play();
            }
        }
    }
