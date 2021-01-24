    [XmlRoot("Keys")]
    public class Keys
    {
    	[XmlElement("Key")]
    	public List<Key> Items { get; set; }          
    }
    
    public class Key
    {
    	[XmlAttribute("TYPE")]
    	public string Type { get; set; } 
    	
    	[XmlText]
    	public string Text {get;set;}
    }
