	//get columns which are of type "string" and then get their names
	var columnNames = dt.Columns.OfType<DataColumn>().Where(c => c.DataType == typeof(string)).Select(c => c.ColumnName).ToList();
	//get all dataTable's rows and with each column name (from previous step) get row's value of that column
	// and if that value contains double qoutes, replace it with empty char :)
	dt.AsEnumerable().ToList().ForEach(
		r => columnNames.ForEach(c => r.SetField<string>(c, r.Field<string>(c).Replace("\"", ""))));
	//or, as one-liner :)
	dt.AsEnumerable().ToList()
		.ForEach(r => dt.Columns.OfType<DataColumn>()
			.Where(c => c.DataType == typeof(string))
			.Select(c => c.ColumnName).ToList()
				.ForEach(c => r.SetField<string>(c, r.Field<string>(c).Replace("\"", ""))));
				
