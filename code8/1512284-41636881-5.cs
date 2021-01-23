    public Task XAsync()
    {
      Task task = YAsync();
      if (task.Status == TaskStatus.RanToCompletion)
        return ZAsync();
      // Do the awaiting
      return XAsync(task);
    }
    private async Task XAsync(Task task)
    {
      await task;
      await ZAsync();
    }
