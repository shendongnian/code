    public void A ()
    {
        IList foo = bar();
        //does work on foo's items
        foo = null;
        GC.Collect(2, GCCollectionMode.Forced); // force GC
        foobar();
        //more code before it goes out of scope
    }
