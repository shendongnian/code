    public static void sReset(this Properties.Settings set, string key = "")
    {
    	if (key == "")
    	{
    		set.Reset();
    		return;
    	}
    	if (set.PropertyValues[key].Property.PropertyType == typeof(StringCollection))
    	{
    		string tvs = (string)set.PropertyValues[key].Property.DefaultValue;
    		set.PropertyValues[key].PropertyValue = tvs.XmlToStringCollection();
    		return;
    	}
    	set.PropertyValues[key].PropertyValue = set.PropertyValues[key].Property.DefaultValue;
    }
    
    public static StringCollection XmlToStringCollection(this string str)
    {
    	StringCollection ret = new StringCollection();
    
    	XmlDocument xmlDoc = new XmlDocument();
    	xmlDoc.LoadXml(str);
    	XmlNodeList terms = xmlDoc.SelectNodes("ArrayOfString/string");
    
    	foreach (XmlElement s in terms)
    	{
    		if (s.InnerXml != "")
    		{
    			Console.WriteLine("Found: " + s.InnerXml);
    			ret.Add(s.InnerXml);
    		}
    	}
    	return ret;
    }
