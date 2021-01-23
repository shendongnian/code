    private OptionalProvider _instance;
    private Func<OptionalProvider> _providerGetter;
    public OptionalProvider Prov
    {
        get { return _instance ?? (_instance = _providerGetter()); }
    }
    public MyProvider(Func<OptionalProvider> getter)
    {
        _providerGetter = getter;
    }
    public void MethodRequiringOptionalProvider()
    {
        // just use property Prov and let Autofac handle the rest
    }
