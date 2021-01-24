    public async void GetData ()
    {
        var getData = await phpApi.getData(category);
        activityImage.IsVisible = true;
        StartAnimationTimer(new CancellationTokenSource());
        foreach (var items in getData["results"])
        {
            ...gathering data    
        }
        activityImage.IsVisible = false;
        if (animateTimerCancellationTokenSource != null)
        {
            animateTimerCancellationTokenSource.Cancel();
            animateTimerCancellationTokenSource.Dispose();
            animateTimerCancellationTokenSource = null;
        }
    }
