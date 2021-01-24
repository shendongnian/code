    public Func<TIn, Task<TOut>> MemoizeAsync<TIn, TOut>(Func<TIn, Task<TOut>> f)
    {
        var cache = new ConcurrentDictionary<TIn, Task<TOut>>();
        Task<TOut> Run (TIn x)=> cache.GetOrAdd(x, f(x));
        return Run;
    }
    var cachedFunc=MemoizeAsync<int,List<Order>>(foo);
