	var config = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<UserViewModel, User>()
		   .AfterMap((source, destination, context) => 
		   { 
		    	var entity = context.Mapper.Map<Entity>(source.SomeProperty);
		   });
		
		cfg.CreateMap<EntityViewModel, Entity>();
	});
	
	var mapper = config.CreateMapper();
	var viewModel = new UserViewModel
	{
		Name = "Test User",
        SomeProperty = new EntityViewModel 
		{ 
			Value = "Sub Class" 
		}
	};
	
	var user = mapper.Map<User>(viewModel);
