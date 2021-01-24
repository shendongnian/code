	var mc = new MapperConfiguration(cfg =>
	{
		cfg.CreateMap<InternalEntity, PublicEntity>()
			.ForMember(dest => dest.PublicName, opt => opt.MapFrom(src => src.InternalName))
            .ForMember(dest => dest.Active, opt => opt.MapFrom(src => src.Active.Value));
	});
