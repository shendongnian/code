    static void Main(string[] args)
	{
		var dt = new DataTable();
		dt.Columns.Add(new DataColumn("column1"));
		var values = new string[] { "8", "9|10", "", "", "5", "11", "3", "", "2" };
	    foreach (var value in values)
	        dt.Rows.Add(value);
		var result = DataTableColumn(dt, "column1");
        // result contains 8, 9, 10, 10, 10, 5, 11, 3, 3, 2
		Console.ReadKey(true);
	}
	public static double[] DataTableColumn(DataTable table, string columnName)
	{
		var split = table.Rows.Cast<DataRow>()
			.SelectMany(r => r[columnName].ToString().Split('|'))
			.ToList();
		var replaceEmpty = split.Select((v, i) => 
               string.IsNullOrEmpty(v) ? Previous(split, i) : v)
			.ToArray();
		return Array.ConvertAll(replaceEmpty, Double.Parse);
	}
	public static string Previous(List<string> list, int index)
	{
		if (index == 0)
			throw new IndexOutOfRangeException();
		var prev = list[index - 1];
		if (string.IsNullOrEmpty(prev))
			return Previous(list, index - 1);
		else
			return prev;
	}
