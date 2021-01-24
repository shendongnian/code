    public Func<TIn, System.Threading.Tasks.Task<TOut>> MemoizeAsync<TIn, TOut>(Func<TIn, Task<TOut>> f)
    {
        var cache = new ConcurrentDictionary<TIn, System.Threading.Tasks.Task<TOut>>();
        return x => cache.GetOrAdd(x, f);         
    }
