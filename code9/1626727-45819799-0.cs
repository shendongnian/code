	Mapper.Initialize(cfg =>
	{
		cfg.CreateProfile("p1", p=>
		{
			p.SourceMemberNamingConvention = new LowerUnderscoreNamingConvention();
			p.CreateMap<Class1, Class2>();
		});
		cfg.CreateProfile("p2", p=>
		{
			p.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
			p.CreateMap<Class2, Class1>();
		});
	}); 
