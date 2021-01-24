    public interface IDAL
    {
    	void BeginTransaction();
    	void EndTransaction();
    	void SaveChanges();
    	DataTable RetrieveData(string query, [CallerMemberName] string callerMemberName = "");
    	string RetrieveString(string query, [CallerMemberName] string callerMemberName = "");
    	bool ExecuteNonQuery(string query, [CallerMemberName] string callerMemberName = "");
    	bool ExecuteNonQuery(string query, object[] parameters, [CallerMemberName] string callerMemberName = "");
    }
    public class MSSQLDAL : IDAL, IDisposable 
    {
    	private bool disposed = false;
    	private string _connectionString { get; set; }
    	private SqlTransaction _transaction { get; set; }
    	private SqlConnection _connection { get; set; }
    	private IsolationLevel _isolationLevel { get; set; }
    	private bool _isCommitted { get; set; }
    
    	public string ConnectionString
    	{
    		get { return _connectionString; }
    	}
    
    	public MSSQLDAL(string connectionString)
    	{
    		this.connectionString = _connectionString;
    		this._connection = new SqlConnection();
    		this._connection.ConnectionString = this._connectionString;
    		this._isolationLevel = IsolationLevel.ReadCommitted;
    		this._isCommitted = false;
    	}
    
    	public void BeginTransaction()
    	{
    		this.Open();
    	}
    
    	public void EndTransaction()
    	{
    		this.Close();
    	}
    
    	public void SaveChanges()
    	{
    		if(_transaction != null)
    		{
    			_transaction.Commit();
    			this._isCommitted = true;
    		}
    		this.EndTransaction();
    	}
    
    	public DataTable RetrieveData(string query, [CallerMemberName] string callerMemberName = "")
    	{
    		DataTable dataTable = new DataTable();
    
    		try
    		{
    			using (SqlCommand command = new SqlCommand())
    			{
    				command.Connection = _connection;
    				command.Transaction = _transaction;
    				command.CommandText = query;
    				command.CommandType = CommandType.Text;
    
    				using (SqlDataAdapter dataAdapter = new SqlDataAdapter(command))
    				{
    					dataAdapter.Fill(dataTable);
    				}
    			}
    
    			//this.AuditSQL(query, string.Empty);
    		}
    		catch (Exception ex)
    		{
    			this.AuditSQL(query, ex.Message, callerMemberName);
    		}
    
    		return dataTable;
    	}
    
    	public string RetrieveString(string query, [CallerMemberName] string callerMemberName = "")
    	{
    		string text = string.Empty;
    
    		try
    		{
    			using (SqlCommand oracleCommand = new SqlCommand())
    			{
    				oracleCommand.Connection = _connection;
    				oracleCommand.Transaction = _transaction;
    				oracleCommand.CommandText = query;
    				oracleCommand.CommandType = CommandType.Text;
    
    				using (SqlDataReader dataReader = oracleCommand.ExecuteReader())
    				{
    					dataReader.Read();
    
    					text = dataReader.GetValue(0).ToString();
    				}
    			}
    
    			//this.AuditSQL(query, string.Empty);
    
    		}
    		catch (Exception ex)
    		{
    			this.AuditSQL(query, ex.Message, callerMemberName);
    		}
    
    		return text;
    	}
    
    	public bool ExecuteNonQuery(string query, [CallerMemberName] string callerMemberName = "")
    	{
    		bool success = false;
    
    		try
    		{
    			using (SqlCommand command = new SqlCommand())
    			{
    				command.Connection = _connection;
    				command.Transaction = _transaction;
    				command.CommandText = query;
    				command.CommandType = CommandType.Text;
    				command.ExecuteNonQuery();
    			}
    
    			//this.AuditSQL(query, string.Empty);
    
    			success = true;
    		}
    		catch (Exception ex)
    		{
    			this.AuditSQL(query, ex.Message, callerMemberName);
    
    			success = false;
    		}
    
    		return success;
    	}
    
    	public bool ExecuteNonQuery(string query, object[] parameters, [CallerMemberName] string callerMemberName = "")
    	{
    		bool success = false;
    
    		try
    		{
    			using (SqlCommand command = new SqlCommand())
    			{
    				command.Connection = _connection;
    				command.Transaction = _transaction;
    				command.CommandText = query;
    				command.CommandType = CommandType.Text;
    				command.Parameters.AddRange(parameters);
    
    				command.ExecuteNonQuery();
    			}
    
    			//this.AuditSQL(query, string.Empty);
    
    			success = true;
    		}
    		catch (Exception ex)
    		{
    			this.AuditSQL(query, ex.Message, callerMemberName);
    
    			success = false;
    		}
    
    		return success;
    	}
    
    	private void Open()
    	{
    		if(_connection.State == ConnectionState.Closed)
    		{
    			_connection.Open();
    			_transaction = _connection.BeginTransaction(_isolationLevel);
    		}            
    	}
    
    	private void Close()
    	{
    		if (!this._isCommitted)
    		{
    			if (this._transaction != null)
    			{
    				this._transaction.Rollback();
    			}
    		}
    		if(this._connection.State == ConnectionState.Open)
    		{
    			this._connection.Close();
    		}
    	}
    
    	private void AuditSQL(string query, string message, string callerMemberName = "")
    	{
    		StringBuilder stringBuilder = new StringBuilder();
    		stringBuilder.AppendLine("**************************************************************************************************");
    		stringBuilder.AppendLine(string.Format("DATETIME: {0}", DateTime.Now.ToString("MM/dd/yyyy HHmmss")));
    		stringBuilder.AppendLine(string.Format("SQL: {0}", query));
    		stringBuilder.AppendLine(string.Format("MESSAGE: {0}", message));
    		if (!string.IsNullOrWhiteSpace(callerMemberName))
    		{
    			stringBuilder.AppendLine(string.Format("METHOD: {0}", callerMemberName));
    		}
    		stringBuilder.AppendLine("**************************************************************************************************");
    
    		Logger.WriteLineSQL(stringBuilder.ToString()); // Log the query result. Add an #if DEBUG so that live version will no longer log.
    	}
    
    	public void Dispose()
    	{
    		Dispose(true);
    		GC.SuppressFinalize(this);
    	}
    
    	protected virtual void Dispose(bool disposing)
    	{
    		if (!disposed)
    		{
    			if (disposing)
    			{
    				if (!this._isCommitted)
    				{
    					if (this._transaction != null)
    					{
    						this._transaction.Rollback();
    					}
    				}
    				this._transaction.Dispose();
    				this._connection.Dispose();
    			}
    			// Free your own state (unmanaged objects).
    			// Set large fields to null.
    			// Free other state (managed objects).
    			this._transaction = null;
    			this._connection = null;
    			disposed = true;
    		}
    	}
    }
