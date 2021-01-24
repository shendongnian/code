    using (SqlConnection connection = new SqlConnection(connectionString))
    {
	    // Create a SqlCommand instance
	    SqlCommand command = new SqlCommand(commandText, connection);
	    // Add the parameter to used in the text box input
	    command.Parameters.Add("@jnumber", SqlDbType.NVarChar, 20).Value = textBox1.Text;
  
	    // open connection
	    connection.Open();
		// create a SqlDataAdapter using the command object with the parameters set
		var dataAdapter = new SqlDataAdapter(command, connectionString);
		// create a data table to hold query
		DataTable dtRecord = new DataTable();
		// fill in data table with the dataAdapater
		dataAdapter.Fill(dtRecord);
		// Display results in  DataGridView
		dataGridView1.DataSource = dtRecord;
    } // Using will close the connection when it disposes it
  
