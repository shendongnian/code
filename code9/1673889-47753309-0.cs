    private Foo foo;
    public Foo Foo
    {
        get { return foo; }
        set
        {
            foo = value;
            OtherProperty = value.SomethingElse;
        }
    }
