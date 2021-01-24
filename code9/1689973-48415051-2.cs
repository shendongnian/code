    public void Command(string query,string conString)
    {
    	SqlDataAdapter adp = new SqlDataAdapter();
    	using (SqlConnection connection = new SqlConnection(conString))
    	{
    
    		try
    		{
    			adp.SelectCommand = new SqlCommand(query,connection);
    			DataTable dtOut = new DataTable();
    			adp.Fill(dtOut);
    			dgCommunications.DataSource = dtOut;
    		}
    		catch (InvalidOperationException)
    		{
    
    		}
    		catch (SqlException)
    		{
    
    		}
    	}
    }
     
