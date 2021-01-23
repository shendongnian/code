    private static void OnSourceChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MediaElementVideoPlayer player = d as MediaElementVideoPlayer;
        if (player != null)
        {
            player.Dispatcher.Invoke(() => {
                if (player.VideoSource != null && player.VideoSource != "")
                {
                    if (player._isPlaying)
                    {
                        player.VideoPlayer.Stop();
                        var uriSource = new Uri(@"/ImageResources/vid-play.png", UriKind.Relative);
                        player.PlayPauseImage.Source = new BitmapImage(uriSource);
                        player._isPlaying = false;
                    } 
                    player.VideoPlayer.Source = new Uri(player.VideoSource);
                    // Start the video playing so that it will show the first frame. 
                    // We're going to pause it immediately so that it doesn't keep playing.
                    player.VideoPlayer.IsMuted = true; // so sound won't be heard
                    player.VideoPlayer.Play();
                }
            });
        }
    }
    private void VideoPlayer_MediaOpened(object sender, RoutedEventArgs e)
    {
        Dispatcher.Invoke(() =>
        {
            // the video thumbnail is now showing!
            VideoPlayer.Pause();
            // reset video to initial position
            VideoPlayer.Position = TimeSpan.FromTicks(0);
            Player.IsMuted = false; // unmute video
            TimeSlider.Minimum = 0;
            // Set the time slider values & time label
            if (VideoPlayer.NaturalDuration != null && VideoPlayer.NaturalDuration != Duration.Automatic)
            {
                TimeSlider.Maximum = VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                TimeSlider.Value = 0;
                double totalSeconds = VideoPlayer.NaturalDuration.TimeSpan.TotalSeconds;
                _durationString = Utilities.numberSecondsToString((int)totalSeconds, true, true);
                TimeLabel.Content = "- / " + _durationString;
            }
        });
    }
