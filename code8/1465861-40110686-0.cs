    void FillData()
	{
	    // 1
	    // Open connection
	    using (SqlConnection c = new SqlConnection(
		Properties.Settings.Default.DataConnectionString))
	    {
		c.Open();
		// 2
		// Create new DataAdapter
		using (SqlDataAdapter a = new SqlDataAdapter(
		    "SELECT * FROM EmployeeIDs", c))
		{
		    // 3
		    // Use DataAdapter to fill DataTable
		    DataTable t = new DataTable();
		    a.Fill(t);
		    // 4
		    // Render data onto the screen
		    // dataGridView1.DataSource = t; // <-- From your designer
		}
	}
