    public class CustomElement<T>
    {
        [XmlText]
        public T Value;
        public CustomElement()
        {
        }
        public CustomElement(T value)
        {
            Value = value;
        }
		[XmlIgnore]
		public bool? Something { get; set; }
	
		[XmlAttribute("something")]
		public bool XmlSomething
		{
			get => Something != null && Something.Value;
			set => Something = value;
		}
		
		public bool ShouldSerializeXmlSomething() => Something.HasValue;
		
        public static implicit operator CustomElement<T>(T x)
        {
            return new CustomElement<T>(x);
        }
    }
    [XmlRoot("item")]
    [XmlType(TypeName = "ci")]
    public class Item
    {
        [XmlElement("attribute1")]
        public CustomElement<string> Attribute1 { get; set; }
        [XmlElement("attribute2")]
        public CustomElement<string> Attribute2 { get; set; }
        [XmlElement("attribute3")]
        public CustomElement<string> Attribute3 { get; set; }
        // Etc Etc
    }
