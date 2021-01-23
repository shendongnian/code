     Public class FilterAction : ConfigurationElement
    {
    [ConfigurationProperty("type", IsRequired = true, IsKey = true)]
    public string Type 
    {
        get { return base["type"] as string; }
        set { base["type"] = value; }
    }
    }
