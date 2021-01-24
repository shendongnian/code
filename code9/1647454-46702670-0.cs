    class A
    {
    private static BlockingCollection<> _ABlockingCollection= new BlockingCollection<>();
    
    
     public BlockingCollection<> A_BlockingCollection
            {
                get  {
                    return _ABlockingCollection;
                }
    ------ Code that Adds elements to the BlockingCollection ------
    A_BlockingCollection.Add(ObjectsForStoring);
    ---------------------------------------------------
    }
    class B
    {
    public B()
    {
    A produce = new A();
    }
    public void Consume()
    {
    --- Code that consumes a Blocking Collection ------
    foreach (var ObjectStored in A.A_BlockingCollection.GetConsumingEnumerable())
     **** Consume *****
    
    }
    }
