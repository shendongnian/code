    public DataView AlleKunden
    {
    	get;
    	private set;
    }
    
    // Use LoadData method anywhere in your ViewModel
    private void LoadData()
    {
    	DataTable dt = new DataTable();
    	try
    	{
    		DatabaseConnection connection = new DatabaseConnection();
    		SqlDataAdapter adapter = new SqlDataAdapter();
    		adapter.SelectCommand = new SqlCommand("Select c_name,l_name,a_town,a_pcode,a_street from dbo.AllCustomers", connection.Connection);
    		adapter.Fill(dt);
    		connection.Connection.Close();
    		AlleKunden = dt.DefaultView;
    	}
    	catch (/* ... */)
    	{
    
    	}
    }
