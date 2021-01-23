    // async / await bridge using FromAsync
    public async Task ReadDataUsingTaskAsync()
    {
	    using(var connection = new SqlConnection(this.Connection.ConnectionString))
	    using(var command = new SqlCommand("SELECT TOP 10 * FROM [core].[application_setting]", connection))
	    {
	    	connection.Open();
	
	    	var datareader = await Task<SqlDataReader>.Factory.FromAsync(
                    command.BeginExecuteReader(CommandBehavior.CloseConnection),
                    command.EndExecuteReader);
					
	    	datareader.HasRows.Dump();
	    }		
    }
