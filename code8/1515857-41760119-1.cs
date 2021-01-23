    public DataTable GetPersonAndWorkExperience(int personId)
    {
    	string connectionString = ""; //load connection string here
    	DataTable result;
    
    	using (SqlConnection conn = new SqlConnection(connectionString))
    	{
    		using (SqlCommand cmd = new SqlCommand("dbo.GetPersonAndWorkExperience"))
    		{
    			cmd.CommandType = CommandType.StoredProcedure;
    			cmd.Parameters.Add(new SqlParameter("@PersonID", personId));
    			conn.Open();
    			cmd.Connection = conn;
    
    			using (SqlDataReader rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
    			{
    				result = new DataTable();
    				result.Load(rdr);
    			}
    		}
    	}
    
    	return result;
    }
