	public static DataSet GetData(string SqlQuery)
	{
		using(var con = new OleDbConnection(conString))
		using(var cmd = new OleDbCommand(SqlQuery, con))
		using(var da = new OleDbDataAdapter(cmd))
		{
			var ds = new DataSet();
			da.Fill(ds);
			return ds;
		}
	}
