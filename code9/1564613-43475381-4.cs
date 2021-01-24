	using(SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["sqlDevConnection"].ConnectionString))
	using(SqlCommand command = new SqlCommand(Q, con))
	{
		con.Open();
		// add parameters correctly based on above example
		command.Parameters.AddWithValue("@val1", recordID);
		command.ExecuteNonQuery();
	}
