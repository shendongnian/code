    // bad
    public SomeClassConstructor()
    {
        _service = new WebService();
    }
    // better
    public SomeClassConstructor(IServiceLocator serviceLocator)
    {
        _service = serviceLocator.GetService<IWebService>();
    }
    // best
    public SomeClassConstructor(IWebService webService)
    {
        _service = webService;
    }
