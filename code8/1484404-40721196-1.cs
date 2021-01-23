    public void BeginScope(string scopeName)
    {
        _savedInstance = _instance;
        _instance = new LoggerForScope( scopeName );
    }
    public void EndScope()
    {
        _instance = _savedInstance;
    }
