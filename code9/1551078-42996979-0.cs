    public virtual Task OpenAsync(CancellationToken cancellationToken)
    {
      TaskCompletionSource<object> completionSource = new TaskCompletionSource<object>();
      if (cancellationToken.IsCancellationRequested)
      {
        completionSource.SetCanceled();
      }
      else
      {
        try
        {
          this.Open();
          completionSource.SetResult((object) null);
        }
        catch (Exception ex)
        {
          completionSource.SetException(ex);
        }
      }
      return (Task) completionSource.Task;
    }
