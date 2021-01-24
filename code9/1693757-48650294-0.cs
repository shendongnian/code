    private Dictionary<string, CancellationTokenSource> DebounceActions = new Dictionary<string, CancellationTokenSource>();
    
    private void Debounce(string key, int millisecondsDelay, Action action)
    {
        if (DebounceActions.ContainsKey(key))
        {
            DebounceActions[key].Cancel();
        }
        DebounceActions[key] = new CancellationTokenSource();
        var token = DebounceActions[key].Token;
        Task.Delay(millisecondsDelay, token).ContinueWith((task) =>
        {
            if (token.IsCancellationRequested)
            {
                token.ThrowIfCancellationRequested();
            }
            else
            {
                action();
            }
        }, token);
    }
