	private void RunSqlCommand(string cmdText, Action<SqlConnection, SqlCommand> execute)
	{
		using (SqlConnection con = new SqlConnection())
		{
			con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
			con.Open();
			using (SqlCommand cmd = new SqlCommand(cmdText, con))
			{
				cmd.Connection = con;
				execute(con, cmd);
			}
		}
	}
