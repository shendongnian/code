    public StoredProcedureResult<T> Translate<T>(string procedureName, SqlParameter[] parameters) where T : class
    {
    	this.command = this.Context.Database.Connection.CreateCommand();
    	this.command.CommandText = procedureName;
    	if (parameters != null)
    		this.command.Parameters.AddRange(parameters);
    	this.command.CommandType = CommandType.StoredProcedure;   
    	this.Context.Database.Connection.Open();    
    	this.Reader = this.command.ExecuteReader();    
    	return new StoredProcedureResult<T>(this.Context, this.Reader);
    }
