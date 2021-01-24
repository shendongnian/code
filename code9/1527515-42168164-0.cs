    protected override async Task RunAsync(CancellationToken cancellationToken)
    {
        await StartWorkAsync(cancellationToken);
    }
    private async Task StartWorkAsync(CancellationToken cancellationToken)
    {
      var delaySpan = TimeSpan.FromMinutes(1);
      try
      {
        while (true)
        {
          await Task.Delay(delaySpan, cancellationToken);
          await someTask.DoWorkAsync(cancellationToken);
        }
      }
      catch (OperationCanceledException)
      {
      }
    }
