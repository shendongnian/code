    [XmlRoot(ElementName="id")]
    	public class Id {
    		[XmlAttribute(AttributeName="value")]
    		public string Value { get; set; }
    	}
    
    	[XmlRoot(ElementName="Module")]
    	public class Module {
    		[XmlElement(ElementName="id")]
    		public List<Id> Id { get; set; }
    		[XmlAttribute(AttributeName="Name")]
    		public string Name { get; set; }
    		[XmlAttribute(AttributeName="Path")]
    		public string Path { get; set; }
    	}
    
    	[XmlRoot(ElementName="identifiers")]
    	public class Identifiers {
    		[XmlElement(ElementName="Module")]
    		public Module Module { get; set; }
    	}
