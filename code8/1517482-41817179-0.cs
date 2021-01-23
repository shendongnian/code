	public sealed class root
	{
		[XmlElement("property1")]
		public List<string> property1;
		[XmlArrayItem(Type = typeof(EUR))]
		[XmlArrayItem(Type = typeof(USD))]
		public List<amount> amount;
	}
	public abstract class amount
	{
		[XmlAttribute]
		public string type { get; set; }
		[XmlText]
		public string Value { get; set; }
	}
	public sealed class EUR : amount { }
	public sealed class USD : amount { }
