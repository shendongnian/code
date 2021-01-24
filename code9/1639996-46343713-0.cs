    comboBox1.Items.Clear();
    connection.Open();
    
    MySqlCommand command = new MySqlCommand(service.selectOnlyWorkerName(), connection);
    MySqlDataAdapter da = new MySqlDataAdapter(command);
    
    using (DataTable dt = new DataTable())
    {
    	da.Fill(dt);
    	foreach (DataRow dr in dt.Rows)
    	{
    
    		comboBox1.Items.Add(dr["worker_name"]);
    	}
    }
    
    connection.Close();
