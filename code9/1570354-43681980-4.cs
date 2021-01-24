    private Task DoRun(IFoo foo) {
      var tcs = new TaskCompletionSource<object>();
      // Regular finish handler
      EventHandler<EventArgs> callback = (sender, args) => tcs.TrySetResult(null);
      RunFoo(foo, callback);
      return tcs.Task;
    }
    public async Task Run(IFoo foo, CancellationToken token = default(CancellationToken)) {
      var tcs = new TaskCompletionSource<object>();
      using (token.Register(() =>
          {
            tcs.TrySetCanceled(token);
            CleanupFoo();
          });
      {
        var task = DoRun(foo);
        try
        {
          await task;
          tcs.TrySetResult(null);
        }
        catch (Exception ex)
        {
          tcs.TrySetException(ex);
        }
      }
      await tcs.Task;
    }
