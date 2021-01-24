    	string[] lines = System.IO.File.ReadAllLines(dir);
		SqlConnection sqlconn = new SqlConnection(DBsetting.Connstring);
		sqlconn.Open();
		SqlTransaction transaction = sqlconn.BeginTransaction();
		foreach (string line in lines)
		{
			...
		}
		transaction.Commit();
		sqlconn.Close();
		sqlconn.Dispose();
