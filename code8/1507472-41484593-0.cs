    private SemaphoreSlim _myTaskBlocker = new SemaphoreSlim(1,1);
    
    public async Task FireAndForgetWithCancel(CancellationToken cancellationToken)
    {
        await _myTaskBlocker.WaitAsync();
    
        try
        {
            //Some potentially long running code.
            cancellationToken.ThrowIfCancellationRequested();
        }
        finally
        {        
            _myTaskBlocker.Release();
        }
    }
