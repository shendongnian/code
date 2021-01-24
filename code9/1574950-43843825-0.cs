    private ObservableCollection<string> col = new ObservableCollection<string>();
    private CancellationTokenSource _refreshCancellation;
    private async void Refresh()
    {
        // cancel the last Refresh action
        if ( _refreshCancellation != null )
        {
            _refreshCancellation.Cancel();
        }
        _refreshCancellation = new CancellationTokenSource();
        var token = _refreshCancellation.Token;
        try
        {
            var newObjects = await GetNewObjectsAsync( token );
            col = new ObservableCollection<string>( newObjects );
        }
        catch ( OperationCanceledException )
        {
        }
    }
    private async Task<ICollection<string>> GetNewObjectsAsync( CancellationToken cancellationToken )
    {
        for ( int i = 0; i < 5; i++ )
        {
            await Task.Delay( 100 ).ConfigureAwait( false );
            // check if we had to cancel, but only where it is safe to cancel
            cancellationToken.ThrowIfCancellationRequested();
        }
        return new List<string> { "a", "b", "c", };
    }
