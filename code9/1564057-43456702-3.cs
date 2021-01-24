	public static class RecordListExtensions
	{
	    public static DataTable ToDataTable(this List<Record> records)
	    {
	        DataTable table = new DataTable();
	        foreach (var field in records.First().Fields) { table.Columns.Add(field.Name); }
	        foreach (var record in records)
	        {
	            table.Rows.Add(record.Fields.Select(field => field.Value).ToArray());
	        }
	        return table;
	    }
	}
