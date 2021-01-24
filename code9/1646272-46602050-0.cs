    using ( var connection = new SqlConnection( _connectionString ) )
    {
    	connection.Open();
    	var transaction = connection.BeginTransaction();
    				
    	try
    	{
    		// create the record header
    		using ( var createRecordCommand = connection.CreateCommand() )
    		{
    			createRecordCommand.CommandText =
    				//"DECLARE @RecordId INT;" + 
    				$"INSERT INTO ..." +
    				"SET @RecordId = scope_identity();";
    							
    			createRecordCommand.Transaction = transaction;
    			createRecordCommand.Parameters.Add( new SqlParameter( "@RecordId", SqlDbType.Int ) { Direction = ParameterDirection.Output } );
    			createRecordCommand.ExecuteNonQuery();
    			recordId = (int) createRecordCommand.Parameters["@RecordId"].Value;
    // ...
    using ( var createAttributeCommand = connection.CreateCommand() )
    {
    	createAttributeCommand.Transaction = transaction;
    	createAttributeCommand.CommandText =
    		$"INSERT INTO ... (RecordId,...) VALUES ({recordId},...)";
    // ...
    transaction.Commit();
