    public class MyObject
    {
    	[XmlArray("Keys")]
    	[XmlArrayItem("Key")]
    	public List<Key> Keys {get;set;}
    }
    
    public class Key
    {
    	[XmlAttribute("TYPE")]
    	public string Type { get; set; } 
    	
    	[XmlText]
    	public string Text {get;set;}
    }
