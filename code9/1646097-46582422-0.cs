    [XmlRoot(ElementName="Position")]
	public class Position {
		[XmlElement(ElementName="X")]
		public string X { get; set; }
		[XmlElement(ElementName="Y")]
		public string Y { get; set; }
		[XmlElement(ElementName="Width")]
		public string Width { get; set; }
		[XmlElement(ElementName="Height")]
		public string Height { get; set; }
	}
	[XmlRoot(ElementName="Dialog")]
	public class Dialog {
		[XmlElement(ElementName="Type")]
		public string Type { get; set; }
		[XmlElement(ElementName="Position")]
		public Position Position { get; set; }
	}
	[XmlRoot(ElementName="Children")]
	public class Children {
		[XmlElement(ElementName="Dialog")]
		public Dialog Dialog { get; set; }
	}
	[XmlRoot(ElementName="UIScheme")]
	public class UIScheme {
		[XmlElement(ElementName="Children")]
		public Children Children { get; set; }
	}
