    private SqlConnection MyConnection()
    {
    	SqlConnection con = new SqlConnection();
    	con.ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;
    	return con;
    }
