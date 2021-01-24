        private void btnUpload_Click(object sender, EventArgs e)
	{
		DataTable dt = new DataTable();
		string strSelect = "SELECT serial, upc, man_date, location, product, created_by, created_date, serial from schema.table where rownum < 2";
		string strInsert = "INSERT INTO schema.table (serial, upc, man_date, location, product, created_by, created_date, serial) VALUES (:serial, :upc, :man_date, :location, :product, :created_by, :created_date, :serial)";
		string conStr = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;
		OracleConnection connection = new OracleConnection(conStr);
		connection.Open();
		if (connection.State != ConnectionState.Open)
		{
			return;
		}
		OracleDataAdapter adapter = new OracleDataAdapter(strSelect, conStr);
		OracleCommandBuilder builder = new OracleCommandBuilder(adapter);
		adapter.Fill(dt);
		dt.Columns["SERIAL"].Unique = true;
		dt.Merge(dtUpload);
		dt.Rows.Remove(dt.Rows[0]);
		foreach (DataRow row in dt.Rows)
		{
			row.SetAdded();
		}
		try
		{
			adapter.Update(dt);
		}
		catch (Exception ex)
		{
			string x = ex.Message + ex.StackTrace;
			throw;
		}
		finally
		{
			connection.Close();
			connection.Dispose();
		}
	}
