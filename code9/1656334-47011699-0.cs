     static void Main(string[] args)
	{
		string CSVPath = @"D:\test.csv";
		string outputText = "";
		using (var reader = File.OpenText(CSVPath))
		{
			outputText = reader.ReadToEnd();
		}
		
		var colSplitter = ',';
		var rowSplitter = new char[] { '\n' };
		
		var rows = (from row in outputText.Split(rowSplitter, StringSplitOptions.RemoveEmptyEntries)
				 let cols = row.Split(colSplitter)
				 from col in cols
				 select new { totalCols = cols.Count(), cols = cols }).ToList();
		int[] maxColLengths = new int[rows.Max(o => o.totalCols)];
		for (int i = 0; i < rows.Count; i++)
		{
			for (int j = 0; j < rows[i].cols.Count(); j++)
			{
				if (rows[i].cols[j].Length > maxColLengths[j])
					maxColLengths[j] = rows[i].cols[j].Trim().Length;
			}
		}
		
		Console.WriteLine(maxColLengths);
	}
