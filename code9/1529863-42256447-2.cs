    static IDisposable PrintLatestData<T>(IObservable<T> stream) {
        return Observable.Interval(TimeSpan.FromMilliseconds(100))
            .WithLatestFrom(stream, (tick, s) => s)
            .Distinct()
            .Select(SlowFunction)
            .Subscribe(Console.WriteLine);
    }
