    private CancellationTokenSource ctsPlay;
    
    private async void playButton_Click(object sender, RoutedEventArgs e)
    {
    	string audioFile = ...;
    	TimeSpan duration = ...;
    
    	ctsPlay = new CancellationTokenSource();
    	playButton.IsEnabled = false;
    	stopButton.IsEnabled = true;
    	try
    	{
    		await PlayAudioAsync(audioFile, duration, ctsPlay.Token);
    	}
    	catch
    	{
    	}
    	ctsPlay.Dispose();
    	ctsPlay = null;
    	stopButton.IsEnabled = false;
    	playButton.IsEnabled = true;
    }
    
    private void stopButton_Click(object sender, RoutedEventArgs e)
    {
    	ctsPlay.Cancel();
    }
