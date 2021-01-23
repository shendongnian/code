    [XmlRoot(ElementName="Error")]
	public class Error {
		[XmlElement(ElementName="cdata-section")]
		public string Cdatasection { get; set; }
	}
	[XmlRoot(ElementName="data")]
	public class Data {
		[XmlElement(ElementName="Error")]
		public Error Error { get; set; }
	}
