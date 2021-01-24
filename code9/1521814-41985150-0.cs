    public virtual void Add(IFoo foo)
    {
        AddOrUpdate(foo);   // If you want "last one wins"
        //GetOrAdd(foo);      // If you want "first one wins"
    }
    private virtual IFoo GetOrAdd(IFoo foo)
    {
        lock(dictionary)
        {
            IFoo result;
            if (!dictionary.TryGetValue(foo.name, out result))
            {
                // Not in the dictionary; add it
                result = foo;
                dictionary.Add(foo.name, foo);
            }
            return result;
        }
    }
    public virtual void AddOrUpdate(IFoo foo)
    {
        lock(dictionary)
        {
            // Last one wins and overwrites if there is a race-condition
            dictionary[foo.name] = foo;
        }
    }
    public virtual IFoo Get(string name)
    {
        lock(dictionary)
        {
            IFoo foo;
            dictionary.TryGetValue(name, out foo);
            return foo; // will be null if TryGetValue returned false
        }
    }
    public virtual bool Has(string name)
    {
        lock(dictionary)
        {
            return dictionary.ContainsKey(name);
        }
        // But there's no guarantee it's still there when this method returns
    }
    public virtual IFoo Remove(string name)
    {
        lock (dictionary)
        {
            IFoo result;
            if (dictionary.TryGetValue(name, out result))
            {
                dictionary.Remove(name);
            }
            return result;
        }
    }
    // Dictionary should be private, not protected to be sure a derived
    // class doesn't access it without using locks
    private readonly IDictionary<string, IFoo> dictionary = new Dictionary<string, IFoo>();
