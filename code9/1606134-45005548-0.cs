    private void PlayMedia(int index)
    { 
        MediaSource mediasource = MediaSource.CreateFromUri(new Uri("ms-appx:///Assets/test.mp3")); 
        mediasource.OpenOperationCompleted += Mediasource_OpenOperationCompleted;
        mediaPlayer.Source = mediasource;
        mediaPlayer.AutoPlay = true; 
        //slider.Maximum = mediaPlayer.PlaybackSession.NaturalDuration.Seconds;
        //System.Diagnostics.Debug.WriteLine(slider.Maximum);
    } 
    private async void Mediasource_OpenOperationCompleted(MediaSource sender, MediaSourceOpenOperationCompletedEventArgs args)
    {       
        var _duration = sender.Duration.GetValueOrDefault();
        await Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, () =>
        {           
            slider.Minimum = 0;
            slider.Maximum = _duration.TotalSeconds;
            slider.StepFrequency = 1;
        });
    }
