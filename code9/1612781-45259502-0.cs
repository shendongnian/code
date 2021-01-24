    public async Task StartWorkAsync(CancellationToken ctoken)
    {
      ctoken.ThrowIfCancellationRequested();
      this.State = "Working";
      try
      {
        await Task.Delay(5000, ctoken);
      }
      catch (OperationCanceledException)
      {
        this.State = "Stopped";
        throw;
      }
    }
