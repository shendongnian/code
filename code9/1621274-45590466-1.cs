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
