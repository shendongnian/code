    public virtual void Add(IFoo foo)
    {
        AddOrUpdate(foo);   // If you want "last one wins"
        //GetOrAdd(foo);      // If you want "first one wins"
    }
    private virtual IFoo GetOrAdd(IFoo foo)
    {
        return concurrentDictionary.GetOrAdd(foo.name, foo);
    }
    public virtual void AddOrUpdate(IFoo foo)
    {
        concurrentDictionary[foo.name] = foo;
    }
    public virtual IFoo Get(string name)
    {
        IFoo result;
        concurrentDictionary.TryGetValue(name, out result);
        return result; // will be null if TryGetValue returned false
    }
    public virtual bool Has(string name)
    {
        return concurrentDictionary.ContainsKey(name);
        // But there's no guarantee it's still there when this method returns
    }
    public virtual IFoo Remove(string name)
    {
        IFoo result;
        concurrentDictionary.TryRemove(name, out result);
        return result;
    }
    private readonly ConcurrentDictionary<string, IFoo> concurrentDictionary = new ConcurrentDictionary<string, IFoo>();
