	[XmlRoot(ElementName="body")]
	public class Body {
		[XmlElement(ElementName="color")]
		public string Color { get; set; }
		[XmlElement(ElementName="type")]
		public string Type { get; set; }
	}
	[XmlRoot(ElementName="details")]
	public class Details {
		[XmlElement(ElementName="year")]
		public string Year { get; set; }
		[XmlElement(ElementName="make")]
		public string Make { get; set; }
	}
	[XmlRoot(ElementName="cars")]
	public class Cars {
		[XmlElement(ElementName="body")]
		public Body Body { get; set; }
		[XmlElement(ElementName="details")]
		public Details Details { get; set; }
	}
	[XmlRoot(ElementName="data")]
	public class Data {
		[XmlElement(ElementName="cars")]
		public List<Cars> Cars { get; set; }
	}
