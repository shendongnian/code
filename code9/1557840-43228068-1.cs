    [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
    public string Name 
    {
	  get { return (string)base["name"]; }
	  set { base["name"] = value; }
    }
