    using(var myConn = new MySqlConnection("yourConnectionString"))
    {
    	try
        {  
    		myConn.Open();
    		if (!rx.IsMatch(txtbxemail.Text))
    		{
    			MyMessageBox.ShowMessage("Invalid format in Email Add field", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Information);
    			myConn.Close();
    			txtbxemail.Clear();
    			txtbxemail.Focus();
    			auto_load_table();
    		}
    		else
    		{
    			myrdr = cmnd.ExecuteReader();
    
    			ExecMyQuery(cmnd, "You are trying to update a record");
    
    			auto_load_table();
    
    			View_all_data disvid = new View_all_data();
    			this.Dispose();
    			disvid.Show();
    
    			while (myrdr.Read())
    			{
    
    			}
    		}
    	}
    	catch (Exception ex)
    	{
    		MessageBox.Show(ex.Message);
    	}
    	myConn.Close();
    }
