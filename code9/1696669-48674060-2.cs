    private void updateValesPonyNumeroFactura(ref string error)
    {
    	string pathFile = @"c:\Temp\";
    	using (OleDbConnection con = new OleDbConnection(GetConnection(pathFile)))
    	{
    		try
    		{
    
    			string updateRow = $"UPDATE vale SET Factura = ? WHERE vale = ?";
    			OleDbCommand cmd = new OleDbCommand(updateRow, con);
    			
    			cmd.Parameters.Add('factura', OleDbType.VarChar);
    			cmd.Parameters.Add('vale', OleDbType.VarChar);
    			
    			cmd.Parameters['factura'].Value = "c00001";
    			cmd.Parameters['vale'].Value = "011395";
    
    			con.Open();
    			cmd.ExecuteNonQuery();
    			con.Close();
    		}
    		catch (Exception ex)
    		{
    			error = ex.Message;
    		}
    		finally
    		{
    			con.Close();
    		}
    	}
    }
