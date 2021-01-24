    public MyClass : IMyClass
    {
        public object[] MyMethod(object[] args){...}
    }
    
    public LoggerDecoratedMyClass : IMyClass
    {
        private readonly IMyClass _inner;
        private readonly ILogger _logger;
        public LoggerDecoratedMyClass(IMyClass inner, ILogger logger)
        {
            _inner = inner;
            _logger = logger;
        } 
        
        public object[] MyMethod(object[] args)
        {
            try
            {
                var result = _inner.MyMethod(args);
                _logger.LogSuccess(...);
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError(..., ex);
                throw;
            }
        }
    }
