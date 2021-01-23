	public YourDbContext() : base("name = YourDbContext")
	{		
		//add these lines in order to avoid from "Self referencing loop detected for ..." error
		this.Configuration.LazyLoadingEnabled = false;
		this.Configuration.ProxyCreationEnabled = false;
	}
