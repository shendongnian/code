    private void btn_Login_Click(object sender, EventArgs e)
    {
    	string userName = textBox1.Text;
    	string password = textBox2.Text;
    	
    	if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(password))
    	{
    		MessageBox.Show("Please provide Username and Password");
    	}
    	else
    	{
    		bool useWindowsAuth = WindowsAuth.Checked; // Assuming that WindowsAuth is your radio button
    
    		var connStrBldr = new System.Data.SqlClient.SqlConnectionStringBuilder();
    		connStrBldr.DataSource = @"172.28.40.19\CASINO2008R2";
    		connStrBldr.InitialCatalog = "GCVS2_DEV_GHR";
    		if (useWindowsAuth ) 
    		{
    			connStrBldr.IntegratedSecurity = true;
    		} else 
    		{
    			connStrBldr.IntegratedSecurity = false;
    			connStrBldr.UserID = userName;
    			connStrBldr.Password = password;
    		}
    		
    		bool validUser = true;
    		
    		try
    		{
    			using (SqlConnection con = new SqlConnection(connStrBldr.ToString())) 
    			{
    				con.Open();
    				//do your lookup on login here
    			}
    		}
    		catch(SqlException) // An exception will be caught if invalid credentials were used.
    		{
    			validUser = false;
    		}
    		
    		if(validUser)
    			MessageBox.Show("Login successful!");
    		else
    			MessageBox.Show("Login failed!");    		
    	}
    }
