    //connection.Open is moved out of the loop, to avoid unnecessary open/close
  	conn = new SqlConnection(connectionString);
    conn.Open();
    try
	{
		foreach (var row in ProductServicesDataGrid.SelectedRows)
		{
			string selectedCode = row.Cells[0].Value.ToString();
	   
			try
			{
				cmd = new SqlCommand("DELETE FROM ProductServices where ProductCode=@productCode", conn);
				cmd.Parameters.Add(.Parameters.Add("productCode", SqlDbType.VarChar).Value = selectedCode;
				sdr = cmd.ExecuteReader();
				//this probably shouldn't be here, but outside the foreach loop.
				//that way table will be loaded after deletion of those n rows.
				//loadProductServicesTable();
		
			
		}
	}
	catch (Exception ex)
	{
		MessageBox.Show(ex.Message);
	}
	finally
	{
		conn.Close();
	}
	//refresh products after deletion
	loadProductServicesTable();
