    public class MyConnectionString : IMyConnectionString, IDisposable
    {
    	private readonly IDbConnection _connection;
    
    	public int ConnectionTimeout => _connection.ConnectionTimeout;
    	public string Database => _connection.Database;
    	public string ConnectionString 
        {     
            get => _connection.ConnectionString; 
            set => _connection.ConnectionString = value; 
        }
    
    	public ConnectionState State => _connection.State;
    
    	public MyConnectionString(IOptions<ConnectionProviderOptions> connProvOpts, EncryptionHelper encHelper)
    	{
    		string con = "some logic to get the connection string.";
    		_connection = new SqlConnection(con);
    	}
    
    	public int Execute(string query, object parameters = null)
    	{
    		return _connection.Execute(query, parameters);
    	}
    }
