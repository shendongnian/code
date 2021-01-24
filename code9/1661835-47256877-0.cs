    public class Items
    {
    	[XmlAttribute()]
    	public int Class{get;set;}
    	
    	[XmlAttribute()]
    	public int Grade{get;set;}
    	
    	[XmlAttribute()]
    	public double Score{get;set;}
    	
    	
        [XmlElement("Item")]
        public List<Item> Item { get; set; }
    	
    	
    }
    
    public class Item
    {
    	[XmlAttribute()]
    	public int ID{get;set;}
    	
    	[XmlAttribute()]
    	public int TemplateID{get;set;}
    	
    	[XmlAttribute()]
    	public int StrengthLevel{get;set;}
    	
    	[XmlAttribute()]
    	public int AttackCompose{get;set;}
    	
    	[XmlAttribute()]
    	public int DefendCompose{get;set;}
    	
    	[XmlAttribute()]
    	public int LuckCompose{get;set;}
    	
    	[XmlAttribute()]
    	public int AgilityCompose{get;set;}
    	
    	[XmlAttribute()]
    	public bool IsBind{get;set;}
    	
    	[XmlAttribute()]
    	public int ValidDate{get;set;}
    	
    	[XmlAttribute()]
    	public int Count{get;set;}
    	
    }
