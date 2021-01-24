    MapperConfiguration config = new MapperConfiguration(c =>     
    { 		
        c.CreateMap<Entity, EntityDto>();
        c.CreateMap(typeof(Foo), typeof(FooDto));
    	c.CreateMap(typeof(Bar<>), typeof(BarDto<>));; 	
    });
    
    config.AssertConfigurationIsValid(); 	
    var mapper = config.CreateMapper();
    BarDto<EntityDto> result = mapper.Map<Bar<Entity>, BarDto<EntityDto>>(AMethodWhichReturnsABar<Entity>());
