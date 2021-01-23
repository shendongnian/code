    private static async Task HandleResultAsync(Task<TimeSpan> operation)
    {
      var result = await operation;
      // A task has finished. This will get executed.
      // result is of type TimeSpan
      ...
    }
    IEnumerable<Task<TimeSpan>> tasks = ...
    IEnumerable<Task> higherLevelTasks = tasks.Select(HandleResultAsync);
    await Task.WhenAll(higherLevelTasks);
