    var config = new MapperConfiguration(cfg => {
        cfg.CreateMap<Search1, SearchFinal>()
            .ForMember(dest => dest.Prop1, opts => opts.MapFrom(src => src.PROP1));
        cfg.CreateMap<Search2, SearchFinal>()
            .ForMember(dest => dest.Prop2, opts => opts.MapFrom(src => src.PROP2));
    });
