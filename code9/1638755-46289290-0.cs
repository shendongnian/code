    var dt = new DataTable();
	dt.Columns.Add("First", typeof(string));
	dt.Columns.Add("Second", typeof(string));
	dt.Columns.Add("Third", typeof(string));
	dt.Columns.Add("Fourth", typeof(string));
	dt.Columns.Add("Fifth", typeof(string));
	for (var i = 1; i < 6; i++)
	{
		dt.Rows.Add($"First {i}", $"Second {i}", $"Third {i}",$"Fourth {i}",$"Fifth {i}");
	}
	
	//dt.Dump();//If you have linqpad this is handy to dump table to output
	
    //REMOVE THE COLUMNS. 
	dt.Columns.RemoveAt(1);
	dt.Columns.RemoveAt(2);	
	//dt.Dump();//again in linqpad this dumps table with remaining 3 columns
