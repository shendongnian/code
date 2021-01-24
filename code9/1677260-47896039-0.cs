	[XmlRoot(ElementName="i")]
	public class I 
	{
		[XmlIgnore]
		public DateTime SomeDate { get; set; }		
		
		[XmlAttribute(AttributeName="Other_Attributes")]
		public string Other_Attributes { get; set; }
		[XmlAttribute(AttributeName="Date_of_Birth")]
		public string Date_of_Birth 
		{ 
			get { return this.SomeDate.ToString("yyyy-MM-dd HH:mm:ss"); }
			set { this.SomeDate = DateTime.Parse(value); }			
		}
		[XmlAttribute(AttributeName="More_Attributes")]
		public string More_Attributes { get; set; }
	}
	[XmlRoot(ElementName="root")]
	public class Root {
		[XmlElement(ElementName="i")]
		public I I { get; set; }
	}
