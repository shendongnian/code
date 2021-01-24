	InsertDetails()
	{
		using (var sqlcon = new SqlConnection(<connectionString>))
		{
            sqlcon.Open();
            // Create transaction to be used by all commands.
            var transaction = sqlcon.BeginTransaction();
			try
			{
				InsertName(transaction, sqlcon);//SQL functions to insert name into name table  
				Insertaddress(transaction, sqlcon);//SQL functions to insert address into address table
				InsertPhoneNo(transaction, sqlcon);//code to insert phone no into contact table
				
				transaction.commit();       
			}
			catch(Exception ex)
			{
				transaction.rollback();
                throw;
			}
		}
	}
    // Typical method implementation.
    private void InsertName(SqlTransaction transaction, SqlConnection sqlcon)
    {
		using (var cmd = sqlcon.CreateCommand())
		{
            // This adds this command to the transaction.
			cmd.Transaction = transaction;
			
			// The rest is fairly typical.
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.CommandText = "InsertStoredProcedureName";
			... set parameters etc.
			cmd.ExecuteNonQuery();
			... handle any OUTPUT parameters etc.
		}
    }
