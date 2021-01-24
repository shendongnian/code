    public async Task PlayAudioAsync(string audioFilePath, TimeSpan duration, CancellationToken cancellationToken)
    {
    	var timeLine = new MediaTimeline(new Uri(audioFilePath));
    	timeLine.RepeatBehavior = RepeatBehavior.Forever;
    	var mediaPlayer = new MediaPlayer();
    	mediaPlayer.Clock = timeLine.CreateClock();
    	mediaPlayer.Clock.Controller.Begin();
    	try
    	{
    		await Task.Delay(duration, cancellationToken);
    	}
    	finally
    	{
    		mediaPlayer.Clock.Controller.Stop();
    	}
    }
