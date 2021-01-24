    public class Item
	{
		[XmlElement(ElementName = "sku")]
		public string Sku { get; set; }
		[XmlElement(ElementName = "style")]
		public string Style { get; set; }
		[XmlElement(ElementName = "reason")]
		public string Reason { get; set; }
	}
	[XmlRoot(ElementName = "items")]
	public class Items
	{
		[XmlElement(ElementName = "item")]
		public List<Item> Item { get; set; }
	}
	[XmlRoot(ElementName = "result")]
	public class Result
	{
		[XmlElement(ElementName = "reporttype")]
		public string Reporttype { get; set; }
		[XmlElement(ElementName = "items")]
		public Items Items { get; set; }
	}
