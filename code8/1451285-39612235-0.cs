    public static void BulkInsert<T>(PandaDataContext db, IList<T> list)
    {
    	var mustOpen = db.Database.Connection.State != ConnectionState.Open;
    	try
    	{
    		if (mustOpen)
    			db.Database.Connection.Open();
    		using (var bulkCopy = new SqlBulkCopy((db.Database.Connection) as SqlConnection, SqlBulkCopyOptions.Default))
    		{
    		}
    	}
    	finally
    	{
    		if (mustOpen)
    			db.Database.Connection.Close();
    	}
    }
