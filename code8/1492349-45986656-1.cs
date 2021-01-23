    private readonly MyOptions _options;
    public MyClass(IWritableOptions<MyOptions> options)
    {
        _options = options.Value;
    }
