    void Main()
    {
    	string xml = @"<language code=""eng"">
    	  <label lang=""tr"">İngilizce</label>
    	   <label lang=""en"">English</label>
    	  </language>";
    
    	XmlSerializer ser = new XmlSerializer(typeof(language));
    	using (MemoryStream ms = new MemoryStream())
    	{
    		XDocument.Parse(xml).Save(ms);
    		ms.Position = 0;
    		var lang = (language)ser.Deserialize(ms);
    		
    		Console.WriteLine(lang.code);
    		foreach (languageLabel lbl in lang.label)
    		{
    			Console.WriteLine(lbl.lang);
    			Console.WriteLine(lbl.Value);
    		}
    	}
    }
    
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class language
    {
    
    	private languageLabel[] labelField;
    
    	private string codeField;
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlElementAttribute("label")]
    	public languageLabel[] label
    	{
    		get
    		{
    			return this.labelField;
    		}
    		set
    		{
    			this.labelField = value;
    		}
    	}
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlAttributeAttribute()]
    	public string code
    	{
    		get
    		{
    			return this.codeField;
    		}
    		set
    		{
    			this.codeField = value;
    		}
    	}
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class languageLabel
    {
    
    	private string langField;
    
    	private string valueField;
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlAttributeAttribute()]
    	public string lang
    	{
    		get
    		{
    			return this.langField;
    		}
    		set
    		{
    			this.langField = value;
    		}
    	}
    
    	/// <remarks/>
    	[System.Xml.Serialization.XmlTextAttribute()]
    	public string Value
    	{
    		get
    		{
    			return this.valueField;
    		}
    		set
    		{
    			this.valueField = value;
    		}
    	}
    }
