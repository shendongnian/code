    private ILogger logger = NullLogger.Instance;
    public CustomerService()
    {
    }
    public ILogger Logger
    {
       get { return logger; }
       set { logger = value; }
    }
