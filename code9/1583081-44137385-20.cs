    public Func<TIn, System.Threading.Tasks.Task<TOut>> MemoizeAsync<TIn, TOut>(Func<TIn, Task<TOut>> f)
    {
        var cache = new ConcurrentDictionary<TIn, System.Threading.Tasks.Task<TOut>>();
        Task<TOut> Run (TIn x) => cache.GetOrAdd(x, f);         
        return Run;
    }
