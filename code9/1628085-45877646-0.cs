    [XmlRoot(ElementName="Field")]
    public class Field {
    	[XmlElement(ElementName="Value")]
    	public string Value { get; set; }
    	[XmlAttribute(AttributeName="Name")]
    	public string Name { get; set; }
    }
    
    [XmlRoot(ElementName="Fields")]
    public class Fields {
    	[XmlElement(ElementName="Field")]
    	public List<Field> Field { get; set; }
    }
    
    [XmlRoot(ElementName="Entity")]
    public class Entity {
    	[XmlElement(ElementName="Fields")]
    	public Fields Fields { get; set; }
    	[XmlAttribute(AttributeName="Type")]
    	public string Type { get; set; }
    }
