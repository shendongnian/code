    using (SqlCommand cmd = new SqlCommand("GetKeyNumber", homelinkconn))
    {
    	//setup the command one time, not in every loop iteration
    	cmd.CommandType = CommandType.StoredProcedure;
    	cmd.Parameters.AddWithValue("@KeyName", "VGMNO");
    	
    	SqlParameter par_KeyNo = new SqlParameter("@KeyNo", SqlDbType.Int);
    	par_KeyNo.Direction = ParameterDirection.Output;
    	cmd.Parameters.Add(par_KeyNo);
    	for (int row = start.Row; row <= end.Row; row++)
    	{
    		cmd.ExecuteNonQuery();
    		var key = par_KeyNo.Value;
    		
    		//unlcear what you want to do here. Currently you would be 
    		//resetting the last row over and over every iteration
    		dt.Rows[????]["VGMNO"] = key;
    	}
    }
