    void Main()
    {
    	string xml = @"<?xml version=""1.0"" encoding=""UTF-8""?>
      <items>
        <item>
            <id>1</id>
            <name>a name</name>
            <address>an address</address>
            <postcode>a postcode</postcode>
        </item>
        <item>
            <id>2</id>
            <name>name 2</name>
            <address>address 2</address>
            <postcode>postcode 2</postcode>
        </item>
        <item>
            <id>3</id>
            <name>name 3</name>
            <address>address 3</address>
            <postcode>postcode 3</postcode>
        </item>
    </items>";
    
    	using (MemoryStream ms = new MemoryStream())
    	{
    		XDocument.Parse(xml).Save(ms);
    		ms.Position = 0;
    		using (var reader = new System.IO.StreamReader(ms))
    		{
    			var serializer = new XmlSerializer(typeof(items));
    			var itemsFullList = (items)serializer.Deserialize(reader);
    		}
    	}
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(ElementName = "items", Namespace = "", IsNullable = false)]
    public partial class items
    {
    
    	private itemsItem[] itemField;
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlElementAttribute("item")]
    	public itemsItem[] item
    	{
    		get
    		{
    			return this.itemField;
    		}
    		set
    		{
    			this.itemField = value;
    		}
    	}
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class itemsItem
    {
    
    	private byte idField;
    
    	private string nameField;
    
    	private string addressField;
    
    	private string postcodeField;
    
    	/// <remarks/>
    	public byte id
    	{
    		get
    		{
    			return this.idField;
    		}
    		set
    		{
    			this.idField = value;
    		}
    	}
    
    	/// <remarks/>
    	public string name
    	{
    		get
    		{
    			return this.nameField;
    		}
    		set
    		{
    			this.nameField = value;
    		}
    	}
    
    	/// <remarks/>
    	public string address
    	{
    		get
    		{
    			return this.addressField;
    		}
    		set
    		{
    			this.addressField = value;
    		}
    	}
    
    	/// <remarks/>
    	public string postcode
    	{
    		get
    		{
    			return this.postcodeField;
    		}
    		set
    		{
    			this.postcodeField = value;
    		}
    	}
    }
