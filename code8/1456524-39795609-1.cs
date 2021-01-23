    protected override IAsyncResult OnBeginGetToken(string appliesTo, string action,
        TimeSpan timeout, AsyncCallback callback, object state)
    {
      var tcs = new TaskCompletionSource<SharedAccessSignatureToken>(state,
          TaskCreationOptions.RunContinuationsAsynchronously);
      var _ = CompleteAsync(GetCustomTokenAsync(appliesTo), callback, tcs);
      // _ is ignored; it can never fault.
      return tcs.Task;
    }
    private static async Task CompleteAsync<TResult>(Task<TResult> task,
        AsyncCallback callback, TaskCompletionSource<TResult> tcs)
    {
      try
      {
        tcs.TrySetResult(await task.ConfigureAwait(false));
      }
      catch (OperationCanceledException ex)
      {
        tcs.TrySetCanceled(ex.CancellationToken);
      }
      catch (Exception ex)
      {
        tcs.TrySetException(ex);
      }
      finally
      {
        // Invoke callback unsafely on the thread pool, so exceptions are global
        if (callback != null)
          ThreadPool.QueueUserWorkItem(state => callback((IAsyncResult)state), tcs.Task);
      }
    }
    protected override SecurityToken OnEndGetToken(IAsyncResult result,
        out DateTime cacheUntil)
    {
      var task = (Task<SharedAccessSignatureToken>)result;
      var ret = task.GetAwaiter().GetResult();
      cacheUntil = ...;
      return ret;
    }
