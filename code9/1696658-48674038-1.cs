    public Logger(ILoggerFactory factory)
    {
        // ...
    
        _logger = factory.CreateLogger(TypeNameHelper.GetTypeDisplayName(typeof(T)));
    }
   
