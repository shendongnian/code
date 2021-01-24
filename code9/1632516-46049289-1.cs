    Task _fooAsyncTask;
    CancellationTokenSource _fooAsyncCancellation;
    async void button1_Click(object sender, EventArgs e)
    {
        _fooAsyncCancellation?.Cancel();
        using (var cts = new CancellationTokenSource())
        {
            _fooAsyncCancellation = cts;
            try
            {
                await FooAsyncHelper(cts.Token);
            }
            catch (OperationCanceledException) { }
            if (_fooAsyncCancellation == cts)
            {
                _fooAsyncCancellation = null;
            }
        }
    }
    async Task FooAsyncHelper(CancellationToken cancellationToken)
    {
        try
        {
            if (_fooAsyncTask != null)
            {
                await _fooAsyncTask;
            }
        }
        catch (OperationCanceledException) { }
        cancellationToken.ThrowIfCancellationRequested();
        await FooAsync(cancellationToken);
    }
    async Task FooAsync(CancellationToken cancellationToken)
    {
        // just some sample work to do
        for (int i = 0; i < 100; i++)
        {
            await Task.Delay(100);
            cancellationToken.ThrowIfCancellationRequested();
        }
    }
