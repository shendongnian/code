    private async Task ScheduleBackGroundWork()
    {
        try
        {
            // Initiate unawaited background tasks
            var backgroundTasks = Enumerable.Range(1, 5)
                .Select(DelayAsync);
            var allCompleteTask = await Task.WhenAll(backgroundTasks)
                .ConfigureAwait(false);
            Trace.WriteLine($"Done waiting for a total of {allCompleteTask.Sum()} seconds");
        }
        catch (Exception)
        {
            Trace.WriteLine("Oops");
        }
    }
