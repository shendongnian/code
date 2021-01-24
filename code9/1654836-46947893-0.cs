	try
	{
		string connectionString = "(CString)";
		string commandText = "sampleone";
		DataTable table = new DataTable();
		using(var con = new SqlConnection(connectionString))
			using(var cmd = new SqlCommand(commandText, con))
				using(var da = new SqlDataAdapter(cmd))
				{
					cmd.Parameters.AddWithValue("@createdOn", "25/10/2017");
					cmd.CommandType = CommandType.StoredProcedure;
					da.Fill(table);
				}
	}
	catch
	{               
	}
