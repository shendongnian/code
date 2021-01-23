    [XmlRoot(ElementName = "author")]
    public class Author
    {
        [XmlAnyElement("name")]
        public XmlElement NameElement { get; set; }
		
		[XmlIgnore]
		public string Name
		{
			get
			{
				return NameElement == null ? null : NameElement.InnerXml;
			}
			set
			{
				if (value == null)
					NameElement = null;
				else
				{
					var element = new XmlDocument().CreateElement("name");
					element.InnerXml = value;
					NameElement = element;
				}
			}
		}
    }
