    // Put this class somewhere useful. Either beside your VM inside the same namespace
    // Or in a seperate file for all your custom operators
    public static class ObservableMixins
    {
        public static IObservable<TOut> ThrottledSelect<TIn, TOut>(this IObservable<TIn> source, int milliseconds, Func<TIn, TOut> selector) =>
            source
                .Where(item => item != null)
                .Throttle(TimeSpan.FromMilliseconds(milliseconds))
                .ObserveOn(TaskPoolScheduler.Default)
                .Select(selector)
                .ObserveOn(RxApp.MainThreadScheduler)
    }
