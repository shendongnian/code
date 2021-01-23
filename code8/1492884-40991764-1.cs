    private async Task StartStopService()
    {
        try
        {
            StartStopInit(true);
            await Task.Run(debugService.Iterate);
        }
        catch (InvalidOperationException ex)
        {
            // What to do here???
        }
        finally
        {
            StartStopInit(false);
        }
    }
