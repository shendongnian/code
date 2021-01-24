    private Task _fooAsyncTask;
    private CancellationTokenSource _fooAsyncCancellation;
    public async Task Button1Click()
    {
        // Assume we're being called on UI thread... if not, the two assignments must be made atomic.
        // Note: we factor out "FooHelperAsync" to avoid an await between the two assignments. 
        // without an intervening await. 
        _fooAsyncCancellation?.Cancel();
        _fooAsyncCancellation = new CancellationTokenSource();
        _fooAsyncTask = FooHelperAsync(_fooAsyncCancellation.Token);
        // no continuation task!
        await _fooAsyncTask;
        _fooAsyncCancellation.Dispose();
        _fooAsyncCancellation = null;
    }
    private async Task FooHelperAsync(CancellationToken cancel)
    {
        try { if (_fooAsyncTask != null) await _fooAsyncTask; }
        catch (OperationCanceledException) { }
        cancel.ThrowIfCancellationRequested();
        await FooAsync(cancel);
    }
    private async Task FooAsync(CancellationToken cancel)
    {
        //
    }
