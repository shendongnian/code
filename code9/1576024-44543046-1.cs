    public class TestBootstrapper : Bootstrapper
    {
    	private const string ConnectionString = "data source=:memory:;cache=shared;";
    	private static SQLiteConnection _connection;
        private static TestInitializer _initializer = new TestInitializer();
            
    	protected override void ConfigureRequestContainer(TinyIoCContainer, NancyContext context) 
    	{
    		container.Register<Context>((_,__) => 
            {
    			if (_connection == null)
    				_connection = new SQLiteConnection(ConnectionString);
        
    			// The false flag tells the context it does not own the connection, i.e. it cannot close it. (EF6 behaviour only)
    			var dbContext = new Context(_connection, _initializer, false);
        
    			if (_connection.State == ConnectionState.Closed)
    				_connection.Open();
        
    			// I build the DB and seed it here
    			_initializer.InitializeDatabase(context);
        
    			return dbContext;
    		});
        
    		// Additional type registrations
    	}
    
    	// Call this method on a [TearDown]
    	public static void Cleanup() 
    	{
            if (_connection != null && _connection.State == ConnectionState.Open)
                _connection.Close();
    		_connection = null;
    	}
    }
