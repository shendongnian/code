    private async Task ShowPhrase()
    {
        while (App.pauseCard || timer1Seconds > 0)
        {
            try
            {
                await Task.Delay(1000, tokenSource1.Token);
            }
            catch (TaskCanceledException)
            {
                // do action
                break;
            }
        }
    }
