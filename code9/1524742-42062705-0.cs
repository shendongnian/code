    public class Bar
    {
    	public int SomeInt { get; set; }
        
    	[XmlIgnore]
    	public string FooString { get; set; }
    	[XmlElement("FooString")]
    	public XmlCDataSection FooStringCData
    	{
    		get { return new XmlDocument().CreateCDataSection(FooString); }
    		set { FooString = (value != null) ? value.Data : null; }
    	}
    }
