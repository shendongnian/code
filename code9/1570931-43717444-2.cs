    using System.Data.SqlClient;
    var connection = new SqlConnection("Your connection");
    {
		var command = connection.CreateCommand();
		SqlTransaction transaction = null;
		try
		{
			connection.Open();
			transaction = connection.BeginTransaction();
			command.Transaction = transaction;
			command.CommandText = "Your query";
			command.ExecuteNonQuery();
			transaction.Commit();
		}
		catch (Exception ex)
		{
			if (transaction != null) transaction.Rollback();
		}
		finally
		{
		   connection.Close();
		}
    }
