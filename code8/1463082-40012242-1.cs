    public IList<Foo> FooList { get; } = new List<Foo>();
    public Foo this[int i]
    {
        get { return FooList[i]; }
        set { FooList[i] = value; }
    }
