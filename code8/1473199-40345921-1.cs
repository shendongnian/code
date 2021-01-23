	CreateMap<BaseEntityClass, DtoClass>()
		.ForMember(dest => dest.Field1, opt => opt.MapFrom(src => src.EntityField1))
		;
	CreateMap<IField3, DtoClass>()
		.ForMember(dest => dest.Field3, opt => opt.MapFrom(src => src.EntityField3))
		;
	CreateMap<ChildEntityClass, DtoClass>()
		.ForMember(dest => dest.Field2, opt => opt.MapFrom(src => src.EntityField2))
		.IncludeBase<BaseEntityClass, DtoClass>()
		.IncludeBase<IField3, DtoClass>()
		;
