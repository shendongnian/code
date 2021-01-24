    public static async Task ProcessAsync(CancellationToken cancellationToken)
    {
        try
        {
            while (true)
            {
                await Task.Delay(TimeSpan.FromMinutes(5), cancellationToken).ConfigureAwait(false);
                Process();
            }
        }
        catch (TaskCanceledException)
        {
            // Cancellation requested, do whatever cleanup you need then exit gracefully
        }
    }
