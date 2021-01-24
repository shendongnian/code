	public class Table
	{
		[XmlElement("thead")]
		public TablePart Header { get; set; }
		[XmlElement("tbody")]
		public TablePart Body { get; set; }
	}
	public class TablePart
	{
		[XmlElement(ElementName = "tr", Namespace = "")]
		public List<TableRow> RowData { get; set; }
	}
	public class TableRow
	{
		[XmlElement("td")]
		public List<string> Data { get; set; }
		[XmlElement("th")]
		public List<string> Headers { get; set; }
	}
	
