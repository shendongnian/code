    // Row is defined below - simple data storage for three the columns
	List<Row> rows = new List<Row>();
	Row currentRow = null;
	
    // Process each line
	foreach (string line in input.Split(new string[] {"\r\n"}, StringSplitOptions.RemoveEmptyEntries))
	{
        // Row separator or content?
		if (line.StartsWith("+"))
		{
			if (currentRow != null)
			{
				rows.Add(currentRow);
				currentRow = null;
			}
		}
		else if (line.StartsWith("|"))
		{
			string[] parts = line.Split(new char[] {'|'});
			if(currentRow == null)
				currentRow = new Row();
			
            // Might need additional processing
			currentRow.Column1 += parts[1].Trim();
			currentRow.Column2 += parts[2].TrimEnd();
			currentRow.Column3 += parts[3].TrimStart();
		}
		else
		{
			//Invalid data?
		}
	}
	
    // Show result
	foreach(Row row in rows)
	{
		Console.WriteLine("[{0}][{1}] = {2}", row.Column1, row.Column2, row.Column3);
	}
