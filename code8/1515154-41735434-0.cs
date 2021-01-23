    private async Task<StartCommandResult> OnStartCommandAsync(Intent intent, StartCommandFlags flags, int startId)
    {
      StartCommandResult a = StartCommandResult.NotSticky;
            Log.Debug(TAG, $"OnStartCommand called at {startTime}, flags={flags}, startid={startId}");
            if (isStarted)
            {
                TimeSpan runtime = DateTime.UtcNow.Subtract(startTime);
                Log.Info(TAG, $"This service was already started, it's been running for {runtime:c}.");
                await UpdateData();
            }
            else
            {
                startTime = DateTime.UtcNow;
                Log.Info(TAG, $"Starting the service, at {startTime}.");
                timer = new Timer(HandleTimerCallback, startTime, 0, TimerWait);
                isStarted = true;
                await UpdateData();
            }
            return a;
    }
