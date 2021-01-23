	public class ItemModel
	{
		public static ItemModel Create(string colstr, string datastr, char delimiter)
		{
			var cols = colstr.Split(delimiter);
			var data = datastr.Split(delimiter);
			var item = new ItemModel();
			item.field1 = int.Parse(GetValue(cols, data, "field1"));
			item.field2 = DateTime.Parse(GetValue(cols, data, "field2"));
			item.field3 = GetValue(cols, data, "field3");
			item.field4 = double.Parse(GetValue(cols, data, "field4"));
			return item;
		}
		public static string GetValue(string[] cols, string[] data, string colName)
		{
			var colid = Array.IndexOf(cols, colName);
			if (colid == -1)
				return null;
			else
				return data[colid];
		}
		public int field1 { get; set; }
		public DateTime field2 { get; set; }
		public string field3 { get; set; }
		public double field4 { get; set; }
	}
