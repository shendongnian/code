    [ConfigurationProperty("name", IsKey = true, IsRequired = true)]
    public string Name 
    {
	  get { return (string)base.Item("name"); }
	  set { base.Item("name") = value; }
    }
