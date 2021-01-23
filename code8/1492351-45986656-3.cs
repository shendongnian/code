    private readonly IWritableOptions<MyOptions> _options;
    public MyClass(IWritableOptions<MyOptions> options)
    {
        _options = options;
    }
