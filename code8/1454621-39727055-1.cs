    // ValueChanged for Slider
    private void TimeSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
    {
        Dispatcher.Invoke(() => {
            TimeSpan videoPosition = TimeSpan.FromSeconds(TimeSlider.Value);
            VideoPlayer.Position = videoPosition;
            TimeLabel.Content = Utilities.numberSecondsToString((int)VideoPlayer.Position.TotalSeconds, true, true) + " / " + _durationString;
        });
    }
    // DragStarted event
    private void slider_DragStarted(object sender, System.Windows.Controls.Primitives.DragStartedEventArgs e)
    {
        Dispatcher.Invoke(() => {
            VideoPlayer.ScrubbingEnabled = true;
            VideoPlayer.Pause();
        });
    }
    // DragCompleted event
    private void slider_DragCompleted(object sender, System.Windows.Controls.Primitives.DragCompletedEventArgs e)
    {
        Dispatcher.Invoke(() => {
            VideoPlayer.ScrubbingEnabled = false;
            TimeSpan videoPosition = TimeSpan.FromSeconds(TimeSlider.Value);
            VideoPlayer.Position = videoPosition;
            if (_isPlaying) // if was playing when drag started, resume playing
                VideoPlayer.Play();
            else
                VideoPlayer.Pause();
        });
    }
