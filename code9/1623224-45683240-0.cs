    public static Func<TArgs, TResult> Memoized<TArgs, TResult>(Func<Func<TArgs, TResult>, TArgs, TResult> factory, IEqualityComparer<TArgs> comparer = null)
    {
        var cache = new ConcurrentDictionary<TArgs, TResult>(comparer ?? EqualityComparer<TArgs>.Default);
        TResult FunctionImpl(TArgs args) => cache.GetOrAdd(args, _args => factory(FunctionImpl, _args));
        return FunctionImpl;
    }
