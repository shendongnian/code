	static MyClass()
	{
	   Defaults = Dictionary<long, Tuple<string,long>>(){
			{ 123, new DefaultValue("Name of default 1", 12312, 23544, ...)},
			{ 456, new DefaultValue("Name of default 2", 36734, 74367, ...)},
		  };
	}
	public static Dictionary<long, Tuple<string,long>> Defaults {get; private set;}
