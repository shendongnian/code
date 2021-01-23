	connection();
	{
		using (SqlCommand cmd = new SqlCommand("Update_F3_BC_Column_Mapping"))
		{
			cmd.CommandType = CommandType.StoredProcedure;
			cmd.Connection = con;
			cmd.Parameters.AddWithValue("@tblF3_BC_Column_Mapping", dtMap);
			cmd.Parameters.Add("@updated_count", SqlDbType.Int).Direction = ParameterDirection.Output;
			cmd.Parameters.Add("@inserted_count", SqlDbType.Int).Direction = ParameterDirection.Output;
