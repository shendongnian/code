    internal struct ScopeLogger : IDisposable
    {
        private readonly string _name;
        public ScopeLogger(ILogger logger, string scopeName, object[] args)
        {
            _name = scopeName;
            _logger = logger;
            _logger.LogInfo("Begin {name}: {args}", _name, args);
        }
        public void Dispose()
        {
            _logger.LogInfo("End {name}",_name);
        }
    }
    
    public static IDisposable LogScope(this ILogger logger, string name, params object[] args)
    {
        return new ScopeLogger(logger, name, args);
    }
