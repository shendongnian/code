    int A = 1;
	string B = "A";
	int C = 1;
	using (SqlConnection conn = new SqlConnection("Connection String")) {
		conn.Open();
		SqlCommand cmd  = new SqlCommand("SP_Search", conn);
		cmd.CommandType = CommandType.StoredProcedure;
		cmd.Parameters.Add(new SqlParameter("@A", A));
		cmd.Parameters.Add(new SqlParameter("@B", B));
		cmd.Parameters.Add(new SqlParameter("@C", C));
		using (SqlDataReader reader = cmd.ExecuteReader()) {
			while (reader.Read())
			{
				//Read Your Data Here
			}
		}
	}
