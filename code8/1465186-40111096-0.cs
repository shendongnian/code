    var cts = new CancellationTokenSource(); // passed into FooAsync
    var getBarAsyncReady = new TaskCompletionSource<object>();
    var getBarAsyncContinue = new TaskCompletionSource<object>();
    bool triggered = false;
    [inject] GetBarAsync = async (barId, cancellationToken) =>
    {
      getBarAsyncReady.SetResult(null);
      await getBarAsyncContinue.Task;
      triggered = cancellationToken.IsCancellationRequested;
      cancellationToken.ThrowIfCancellationRequested();
    };
    
    var task = FooAsync(cts.Token);
    await getBarAsyncReady.Task;
    cts.Cancel();
    getBarAsyncContinue.SetResult(null);
    Assert(triggered);
    Assert(task throws OperationCanceledException);
