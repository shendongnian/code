    public Func<TIn, Task<TOut>> MemoizeAsync<TIn, TOut>(Func<TIn, Task<TOut>> f)
    {
        var cache = new ConcurrentDictionary<TIn, Task<TOut>>();
        return x => cache.GetOrAdd(x, f);         
    }
