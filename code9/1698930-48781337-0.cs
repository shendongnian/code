	public static DataTable getDataTable(string sSQL, SqlConnection conn)
	{
		DataTable dtGeneric = new DataTable();
		SqlCommand command = new SqlCommand();
		DataSet oDataSet = new DataSet();
		//create a new dataset...
		oDataSet.Clear();
		SqlDataAdapter objDataAdapter = new SqlDataAdapter(sSQL, conn);
		objDataAdapter.SelectCommand.CommandTimeout = 900;
		try
		{
			objDataAdapter.Fill(oDataSet, "Generic"); //fill dataSet with data...
			dtGeneric = oDataSet.Tables["Generic"];
		}
		catch (System.Exception e)
		{
			Debug.WriteLine(e.ToString());
			return null;
		}
		finally
		{
			dtGeneric.Dispose();
			objDataAdapter.Dispose();
			command.Dispose();
			conn.Close();
		}
        
       return dtGeneric;
	}
