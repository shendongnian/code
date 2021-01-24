    private readonly IOwinAppBuilder _startup;
    private readonly string _appRoot;
    private readonly ServiceInitializationParameters _parameters;
    
    private string _listeningAddress;
    private IDisposable _serverHandle;
    public OwinCommunicationListener(
            string appRoot,
            IOwinAppBuilder startup,
            ServiceInitializationParameters serviceInitializationParameters
            )
        {
            _startup = startup;
            _appRoot = appRoot;
            _parameters = serviceInitializationParameters;
        }
