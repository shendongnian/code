    public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory,
        Func<TDisposable, TResult> fn) where TDisposable : IDisposable {
        using (var disposable = factory()) {
            return fn(disposable);
        }
    }
