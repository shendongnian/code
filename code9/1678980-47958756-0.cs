    private async Task DoDoneAsync()
    {
        FlagCommandDone = true;
    
        try
        {
            await DoDoneLoopAsync();
        }
        catch (Exception e)
        {
            isError = true;
            message = e.Message;
        }
    
        if (!isError) message = task.IsCompleted ? "Completed" : "Canceled";
    
        MessageBox.Show(message);
    
        FlagCommandDone = false;
    }
    private async Task DoDoneLoopAsync()
    {
        double i = 0;
        while (i < 3)
        {
            i++;
            await PauseToken.WaitWhilePausedAsync();
            await Task.Delay(5000);
        }
    }
