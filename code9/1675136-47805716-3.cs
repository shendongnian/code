	const string RowDelimiter = "#####";
	const string ColumnDelimiter = "'~'";
	
	using (var reader = new StreamReader(inputFilename))
    using (var writer = new StreamWriter(File.Create(ouputFilename)))
	{
		foreach (var row in ReadDelimitedRows(reader, RowDelimiter))
		{
			writer.Write(row.Replace(ColumnDelimiter, "\t"));
		}
	}
