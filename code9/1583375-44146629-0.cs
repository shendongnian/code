    async void StartAnimationTimer(CancellationTokenSource tokenSource)
    {
        try
        {
            //maintain a reference to the token so we can cancel when needed
            animateTimerCancellationTokenSource = tokenSource;
            int idleTime = 1000; //ms
            await Task.Delay(TimeSpan.FromMilliseconds(idleTime), tokenSource.Token);
            //Do something here
            Device.BeginInvokeOnMainThread(() =>
            {
                if (activityImage.isVisible)
                {
                    activityImage.RelRotateTo(500, 1000, Easing.SinOut);
                    //Do this if you want to have it possibly happen again
                    StartAnimationTimer(new CancellationTokenSource());
                }
            });
        }
        catch (TaskCanceledException ex)
        {
            //if we cancel/reset, this catch block gets called
            Debug.WriteLine(ex);
        }
        // if we reach here, this timer has stopped
    }
