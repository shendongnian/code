    Dictionary<Tuple<Type, Type>, bool> cache = new Dictionary<Tuple<Type, Type>, bool>();
    Dictionary<(Type, Type), bool> cache4 = new Dictionary<(Type, Type), bool>();
    ConcurrentDictionary<Tuple<Type, Type>, bool> cache2 = new ConcurrentDictionary<Tuple<Type, Type>, bool>();
    ConcurrentDictionary<(Type, Type), bool> cache3 = new ConcurrentDictionary<(Type, Type), bool>();
    var p = new Dictionary<string, Action>()
    {
        { "no chache", ()=> typeof(F).IsSubclassOf(typeof(A)) },
        {
            "dic cache", ()=>
            {
                var key = Tuple.Create(typeof(F),typeof(A));
                if(!cache.TryGetValue(key, out var value))
                {
                    cache.Add(key, typeof(F).IsSubclassOf(typeof(A)));
                }
            }
        },
        {
            "vtuple + dic cache", ()=>
            {
                var key = (typeof(F),typeof(A));
                if(!cache4.TryGetValue(key, out var value))
                {
                    cache4.Add(key, typeof(F).IsSubclassOf(typeof(A)));
                }
            }
        },
        {
            "concurrent dic cache", ()=>
            {
                cache2.GetOrAdd(Tuple.Create(typeof(F),typeof(A)), (k)=> typeof(F).IsSubclassOf(typeof(A)));
            }
        },
        {
            "vtuple + concurrent + dic cache", ()=>
            {
                cache3.GetOrAdd((typeof(F),typeof(A)), (k)=> typeof(F).IsSubclassOf(typeof(A)));
            }
        },
    };
