	[XmlRoot(ElementName = "category")]
	public class Category
	{
		[XmlElement(ElementName = "books")]
		public Books Books { get; set; }
	
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}
	
	[XmlRoot(ElementName = "books")]
	public class Books
	{
		[XmlElement(ElementName = "book")]
		public List<string> Book { get; set; }
	}
