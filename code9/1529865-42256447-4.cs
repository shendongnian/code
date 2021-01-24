    static IDisposable PrintLatestData<T>(IObservable<T> stream) {
        return stream.Sample(TimeSpan.FromMilliseconds(100))
            .Select(SlowFunction)
            .Subscribe(Console.WriteLine);
    }
