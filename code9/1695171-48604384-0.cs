    private void statelist_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    	businessGrid.Items.Clear();
    	//clear your citylist,if you selected other state.
    	citylist.Items.Clear();
    	if (statelist.SelectedIndex > -1)
    	{
    		using (var conn = new NpgsqlConnection(buildConnString()))
    		{
    			conn.Open();
    			using (var cmd = new NpgsqlCommand())
    			{
    				cmd.Connection = conn;
    				cmd.CommandText = "SELECT name,state FROM business WHERE state = '" + statelist.SelectedItem.ToString()+ "';";
    				using (var reader = cmd.ExecuteReader())
    				{
    					while (reader.Read())
    					{
    						while (reader.Read())
    						{
    							businessGrid.Items.Add(new Business() { name = reader.GetString(0), state = reader.GetString(1) });
    
    						}
    					}
    				}
    			}
    			conn.Close();
    		}
    		//create cities list by statelist's value
    		addCities();
    	}
    }
    private void citylist_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
    	businessGrid.Items.Clear();
    	if (citylist.SelectedIndex > -1)
    	{
    		using (var conn = new NpgsqlConnection(buildConnString()))
    		{
    			conn.Open();
    			using (var cmd = new NpgsqlCommand())
    			{
    				//Business b = new Business(); you do not need create a Business model
    				//you need to get user selected state's value to query.
    				string statelist = statelist.SelectedItem.ToString(); 
    				cmd.Connection = conn;
    				cmd.CommandText = "SELECT name,state,city FROM business WHERE state = '" + statelist + " ORDER BY " + citylist.SelectedItem.ToString() + ";"; ##Problem is with this line
    				using (var reader = cmd.ExecuteReader())
    				{
    					while (reader.Read())
    					{
    						while (reader.Read())
    						{
    							businessGrid.Items.Add(new Business() { name = reader.GetString(0), state = reader.GetString(1), city = reader.GetString(2) });
    
    						}
    					}
    				}
    			}
    			conn.Close();
    		}
    	}
    }
    public void addCities()
    {
    	using (var conn = new NpgsqlConnection(buildConnString()))
    	{
    		conn.Open();
    		using (var cmd = new NpgsqlCommand())
    		{
    			//Business b = new Business(); you do not need create a Business model
    			//you need to get user selected state's value to query.
    			string statelist = statelist.SelectedItem.ToString(); 
    			
    			cmd.Connection = conn;
    			cmd.CommandText = "SELECT distinct city FROM business WHERE state = '" + statelist.SelectedItem.ToString() + "';"; ##Problem is with this line
    			using (var reader = cmd.ExecuteReader())
    			{
    				while (reader.Read())
    				{
    					while (reader.Read())
    					{
    						citylist.Items.Add(reader.GetString(0));
    						//statelist.Items.Add(reader.GetString(1)); There is not 2 field in your sql syntans
    					}
    				}
    			}
    		}
    		conn.Close();
    
    	}
    }
    public MainWindow()
    {
    	InitializeComponent();
    	addStates();
    	addColumns2Grid();
    }
