    using System;
    public class MyConnectionString : IMyConnectionString, IDisposable
    {
    	private readonly IDbConnection _connection;
        private readonly ISqlConnectionFactory _factory;
    
    	public int ConnectionTimeout => _connection.ConnectionTimeout;
    	public string Database => _connection.Database;
    	public string ConnectionString 
        {     
            get => _connection.ConnectionString; 
            set => _connection.ConnectionString = value; 
        }
    
    	public ConnectionState State => _connection.State;
    
    	public MyConnectionString(IOptions<ConnectionProviderOptions> connProvOpts, EncryptionHelper encHelper, ISqlConnectionFactory factory)
    	{
            _factory = factory;
            _connection = _factory.CreateConnection(connProvOpts, encHelper);
    	}
    
    	public int Execute(string query, object parameters = null)
    	{
    		return _connection.Execute(query, parameters);
    	}
    }
    public interface ISqlConnectionFactory
    {
        SqlConnection CreateConnection(IOptions<ConnectionProviderOptions> connProvOpts, EncryptionHelper encHelper);
    }
    public class SqlConnectionFactory : ISqlConnectionFactory
    {
        public SqlConnectionFactory()
        {
             // Maybe initialization?
        }
        public SqlConnection CreateConnection(IOptions<ConnectionProviderOptions> connProvOpts, EncryptionHelper encHelper)
        {
    		string con = "some logic to get the connection string.";
    		_connection = new SqlConnection(con);
        }
    }
