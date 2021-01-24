    private void btnDelete_Click(object sender, EventArgs e)
    {
    	string query = "DELETE FROM Clients WHERE ClientID = @ClientID";
    
    	using (OleDbConnection myDb = new OleDbConnection(connectionString + DBFile))
    	using (OleDbCommand command = myDb.CreateCommand())
    	{
    		int clientid = 0;
    
    		command.CommandText = query;
    
    		OleDbParameter parClientID = new OleDbParameter("@ClientID", OleDbType.Integer);
    		command.Parameters.Add(parClientID);
    
    		myDb.Open();
    
    		foreach (DataGridViewRow myRow in dataGridView1.SelectedRows)
    		{
    			//Assume your client id is in a cell of the row? Zero for first, One for second, etc.
    			if (int.TryParse(myRow.Cells[0].ToString(), out clientid))
    			{
    				parClientID.Value = clientid;
    				command.ExecuteNonQuery();
    			}
    		}
    	}
    }
