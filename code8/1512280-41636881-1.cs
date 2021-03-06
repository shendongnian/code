    public Task XAsync()
    {
      Task task = YAsync();
      switch(task.Status)
      {
        case TaskStatus.Canceled:
        case TaskStatus.Faulted:
          // pass the failure up the stack
          return task;
        case TaskStatus.RanToCompletion:
          // YAsync is done already, so we can pass
          // the next task back immediately.
          return ZAsync();
        default;
          // Do the awaiting
          return XAsync(task);
      }
    }
    private async Task XAsync(Task task)
    {
      await task;
      await ZAsync();
    }
