    public void Save1(List<SqlParameter> param)
    {
    	try
    	{
    		using (SqlConnection con = new SqlConnection(ConfigurationManager
                .ConnectionStrings["myCon"].ConnectionString))
    		{
    			using (SqlCommand cmd = new SqlCommand("SP_TEST", con))
    			{
    				cmd.CommandType = CommandType.StoredProcedure;
    				foreach (var item in param)
    					cmd.Parameters.Add(item);
    				cmd.ExecuteNonQuery();
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		/*...*/
    	}
    }
