    public static DataTable SelectData()
    {
        var ConnString = ConfigurationManager.ConnectionStrings["YourConnectionString"].ConnectionString;
        SqlDataAdapter sda;
        DataTable dt;
        using (SqlConnection connStr = new SqlConnection(ConnString))
       	{
            using (SqlCommand cmd = new SqlCommand("SELECT firstname, dob, ChildID FROM children", connStr))
            {
            	cmd.CommandType = CommandType.Text;
            	sda = new SqlDataAdapter(cmd);
            	dt = new DataTable();
          		new SqlDataAdapter(cmd).Fill(dt);
          	}
        }
        return dt;
    }
