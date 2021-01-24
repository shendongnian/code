    // define connection string (typically loaded from config) and query as strings
    string connString = "Data Source=.;Initial Catalog=sms;Persist Security Info=True;User ID=boy;Password=coco";
    string query = "SELECT id FROM dbo.Staff_Management WHERE Emp_Name = @EmpName;";
    
    // define SQL connection and command in "using" blocks
    using (SqlConnection con = new SqlConnection(connString))       
    using (SqlCommand cmd = new SqlCommand(query, con))
    {
        // set the parameter value
    	cmd.Parameter.Add("@EmpName", SqlDbType.VarChar, 100).Value = sName;
    
    	// open connection, execute scalar, close connection
        con.Open();
        object result = cmd.ExecuteScalar();
        con.Close();
    
        int id;
    	
    	if(result != null)
    	{
    		if (int.TryParse(result.ToString(), out id)
    		{
    		    // do whatever when the "id" is properly found	
    		}
    	}
    }
