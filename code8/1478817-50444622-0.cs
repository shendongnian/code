	string ConnStr = System.Configuration.ConfigurationManager.ConnectionStrings["connstr"].ConnectionString;
	string SQL1 = "INSERT INTO tbl_cust(cust_id,cust_name) values ('000001','YoungMcD') ";
	string SQL2 = "UPDATE tbl_cust SET custname='OldMcDonald' WHERE cust_id='000001'";
	using (SqlConnection conn = new SqlConnection(ConnStr))
	{
		SqlTransaction transaction = null;
		try
		{
			conn.Open();
			transaction = conn.BeginTransaction();
			using (SqlCommand cmd = new SqlCommand(SQL1, conn, transaction)) { cmd.ExecuteNonQuery(); }
			using (SqlCommand cmd = new SqlCommand(SQL2, conn, transaction)) { cmd.ExecuteNonQuery(); }
			transaction.Commit();
			savestats = true;
		}
		catch (Exception ex)
		{
			 // Attempt to roll back the transaction.
			try
			{
				transaction.Rollback();
			}
			catch (Exception ex2)
			{
				// This catch block will handle any errors that may have occurred
				// on the server that would cause the rollback to fail, such as
				// a closed connection.
			}
		}
	}
