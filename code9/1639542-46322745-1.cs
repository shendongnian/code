    try
    {
    	var sql = "SELECT Username, Type  FROM Users WHERE Username = @username AND Password = @password AND STATUS = 'IN'"
    	var isLogin = false; //check if user successfully logged it
    	var userType = ""; //for user type...
    	using (var sqlConn = new SqlConnection("your connection string"))
    	{
    		sqlConn.Open();
    		var sqlCmd = new SqlCommand(sql, sqlConn);
    		sqlCmd.Parameters.Add(new SqlParameter("@username", username));
            sqlCmd.Parameters.Add(new SqlParameter("@password", password)); //I hope you had this field...
    		using (var reader = sqlCmd.ExecuteReader())
    		{
    			while(reader.Read())
    			{
    				textBox1.Text = reader["Username"].ToString(); //put it to the text box.
    				userType = reader["Type"].ToString(); //put the result type in the variable..
    				isLogin = true;
    			}
    		}
    	}
    	
    	//check if has user
    	if (isLogin)
    	{
    		//just check the user type variable...
    		if (userType == "ADMIN")
    		{
    			button2.Visible = true;
    			button3.Visible = true;
    			button4.Visible = true;
    			button5.Visible = true;
    			button1.Visible = true;
    			button6.Visible = false;
    		}
    		else
    		{
    			button2.Visible = false;
                button3.Visible = false;
                button4.Visible = false;
                button5.Visible = false;
                button1.Visible = true;
                button6.Visible = true;
    		}
    	}
    	else
    	{
    		MessageBox.Show("User doen't exist");
    	}
    	
    }
    catch(Exception ex)
    {
    	MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
    }
