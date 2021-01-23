    private object lockObject = new object();
    public string SomeProperty
    {
        get
        {
            lock (lockObject)
                return "A string";
        }
    }
