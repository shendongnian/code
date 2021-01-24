    foreach (var row in ProductServicesDataGrid.SelectedRows)
    {
    	string selectedCode = row.Cells[0].Value.ToString();
    
    	conn = new SqlConnection(connectionString);
    
    	try
    	{
    		conn.Open();
    		cmd = new SqlCommand("DELETE FROM ProductServices where ProductCode=@productCode", conn);
    		cmd.Parameters.Add(.Parameters.Add("productCode", SqlDbType.VarChar).Value = selectedCode;
    		sdr = cmd.ExecuteReader();
            //this probably shouldn't be here, but outside the foreach loop.
            //that way table will be loaded after deletion of those n rows.
    		loadProductServicesTable();
    
    	}
    	catch (Exception ex)
    	{
    
    		MessageBox.Show(ex.Message);
    	}
    	finally
    	{
    		conn.Close();
    	}
    }
