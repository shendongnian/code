    using System.Xml.Serialization;
    
    [System.Serializable()]
    [XmlType(AnonymousType = true)]
    [XmlRoot("root", Namespace = "", IsNullable = false)]
    public partial class Root
    {
    
    	[XmlElement("element", typeof(string))]
    	[XmlElement("element", typeof(string), Namespace = "http://example.com/ns")]
    	[XmlChoiceIdentifier("ElementType")]
    	public string Element { get; set; }
    
    	[XmlIgnore()]
    	public ElementType ElementType { get; set; }
    
    	[XmlElement("secondElement", typeof(string), Namespace = "http://example.com/ns")]
    	[XmlElement("secondElement", typeof(string))]
    	[XmlChoiceIdentifier("SecondElementType")]
    	public string SecondElement { get; set; }
    
    	[XmlIgnore()]
    	public SecondElementType SecondElementType { get; set; }
    }
    
    /// <remarks/>
    [System.Serializable()]
    [XmlType(IncludeInSchema = false)]
    public enum ElementType
    {
    	element,
    	[XmlEnum("http://example.com/ns:element")]
    	nsElement,
    }
    
    /// <remarks/>
    [System.Serializable()]
    [XmlType(IncludeInSchema = false)]
    public enum SecondElementType
    {
    	secondElement,
    	[XmlEnum("http://example.com/ns:secondElement")]
    	nsSecondElement,
    }
