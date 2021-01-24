    try
    {
    	connection.Open();
    	MySqlDataAdapter adapter = new MySqlDataAdapter("SELECT * FROM User", connection);
    	DataTable data = new DataTable();
    	adapter.Fill(data);
    	foreach (DataRow row in data.Rows)
    	{
    		Console.WriteLine(row["COLUMN_NAME"]);
    	}
    }
    catch (Exception ex)
    {
    	throw ex;
    }
    finally
    {
    	connection.Close();
    }
