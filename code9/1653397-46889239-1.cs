    public static void Update(Foo foo)
    {
        // add a new locker object for each foo if it's not already in dictionary
        ThreadLockDict.TryAdd(foo.Id, new object());
        lock (ThreadLockDict[foo.Id])
        {
            // some code
        }
    }
