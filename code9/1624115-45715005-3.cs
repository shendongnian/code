    private void button1_Click(object sender, EventArgs e)
    {
    	int RowsAffected = 0;
    	
        connection.Open();
        string query = "DELETE FROM Hoteldb WHERE ID=@ID";
        command = new OleDBCommand(query);
        command.Connection = connection;
    	
    	cmd.Parameters.Add(new OleDbParameter("@ID", OleDbType.WChar, 150, "ID"));
    	cmd.Parameters["@ID"].Value = textBox0.Text.Trim()
    	RowsAffected = command.ExecuteNonQuery();
        if(RowsAffected > 0)
    	{
    		MessageBox.Show("Guest Checked Out succesfly");
    		BindGridView();
    	}
    	else
    	{
    		MessageBox.Show("There was nothing to be deleted");
    	}
    }
    public void BindGridView()
    {
    	connection.Open();
        string strSQL = "SELECT * FROM Hoteldb";  
        cmd = new OleDbCommand(strSQL);
    	cmd.Connection = connection;
    	
        OleDbDataAdapter da = new OleDbDataAdapter(cmd);
        DataSet ds = new DataSet();
        da.Fill(ds, "Hoteldb");
        dataGridView1.DataSource = ds.Tables["Hoteldb"].DefaultView
    
        connection.Close();
    }
