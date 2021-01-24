    public void Execute()
    {
        int executionCount = 0;
        var replay = new ReplaySubject<T>();
        _results.OnNext(Observable.Create<T>(obs =>
        {
            var subscriptions = new CompositeDisposable();
            if (1 == Interlocked.Increment(ref executionCount))
            {
                subscriptions.Add(Observable
                    .Empty<T>()
                    .Finally(TaskStarted) // Sets IsExecuting to true 
                    .Concat(_execute())
                    .Do(replay)
                    .Finally(TaskFinished) // Sets IsExecuting to false
                    .Subscribe());
            }
            subscriptions.Add(replay.Subscribe(obs));
            return subscriptions;
        }));
