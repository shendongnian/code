	static DataTable GetTable()
	{
		// Here we create a DataTable with four columns.
		DataTable table = new DataTable();
		table.Columns.Add("laborer", typeof(string));
		table.Columns.Add("trx_date", typeof(string));
		// Here we add five DataRows.
		table.Rows.Add("Indocin", "12/12/2010");
		table.Rows.Add("Enebrel", "12/1/2011");
		table.Rows.Add("Hydralazine", "1/12/2012");
		table.Rows.Add("Combivent", "11/12/2013");
		table.Rows.Add("Dilantin", "12/11/2014");
		return table;
	}
