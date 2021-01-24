    public void Execute()
    {
        int subscriptionCount = 0;
        int executionCount = 0;
        var result = new ReplaySubject<T>();
        var disposeLastSubscription = new Subject<Unit>();
        _results.OnNext(Observable.Create<T>(obs =>
        {
            Interlocked.Increment(ref subscriptionCount);
            if (Interlocked.Increment(ref executionCount) == 1)
            {
                IDisposable copySourceToReplay = Observable
                    .Defer(_execute)
                    .TakeUntil(disposeLastSubscription)
                    .Subscribe(result);
            }
            return new CompositeDisposable(
                result.Subscribe(obs),
                Disposable.Create(() =>
                {
                    if (Interlocked.Decrement(ref subscriptionCount) == 0)
                    {
                        disposeLastSubscription.OnNext(Unit.Default);
                    }
                }));
        }));
    }
