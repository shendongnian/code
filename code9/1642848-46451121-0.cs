    public void GenericMethod<T>(IEnumerable<T> p) where T : class, ISomeInterface
    {
        IEnumerable<ISomeInterface> e = p;
        // or
        TestMethod(p);
    }
