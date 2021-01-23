    private static Lazy<IConnectionMultiplexer> _redisMux = new Lazy<ConnectionMultiplexer>(CreateMultiplexer);
    public static IConnectionMultiplexer Multiplexer { get { return _redisMux.Value; } }
    
    private const string Main   = "192.168.XXX.YY:6379,abortConnect=false";
    private const string Backup = "192.168.XXX.YY:6379,abortConnect=false";
    
    private static string ActiveConfig = Main;
    
    private static ConnectionMultiplexer CreateMultiplexer()
    {
    	var mux = ConnectionMultiplexer.Connect(ActiveConfig));
    	mux.ConnectionFailed += OnConnectionFailed;
    	
    	return mux;
    }
    
    [MethodImpl(MethodImplOptions.Synchronized)]
    private static void OnConnectionFailed(object sender, ConnectionFailedEventArgs e)
    {
    	ActiveConfig = Backup;
    	
    	try { Multiplexer.Dispose(); } catch { }
    	_redisMux = new Lazy<ConnectionMultiplexer>(CreateMultiplexer);
    }
