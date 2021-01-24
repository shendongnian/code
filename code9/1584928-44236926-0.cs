    [Timeout("00:00:30")]
    [Singleton]
    public async static Task PeriodicProcess([TimerTrigger("00:00:10", RunOnStartup = true)] TimerInfo timer, CancellationToken cancelToken, TextWriter log)
    {
        log.WriteLine($"-- [{DateTime.Now.ToString()}] Processing Begin --");
        try
        {
            await longRunningJob(log, cancelToken);
        }
        catch (Exception e)
        {
            // do stuff
        }
        log.WriteLine($"-- [{DateTime.Now.ToString()}] Processing End -- ");
    }
    private async static Task longRunningJob(TextWriter log, CancellationToken cancelToken)
    {
        log.WriteLine($"-- [{DateTime.Now.ToString()}] Begin Time-consuming jobs --");
        await Task.Delay(TimeSpan.FromMinutes(1), cancelToken);
        log.WriteLine($"-- [{DateTime.Now.ToString()}] Complete Time-consuming jobs --");
    }
