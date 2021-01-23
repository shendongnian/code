    private static void Configure()
    {
        Mapper.Initialize(cfg =>
        {
            cfg.CreateMap<SourceType, DestType>()
                .ForMember(dest => dest.Method, opt => opt.MapFrom(src => 
                    src.MethodName == "MANUAL" ? Method.MANUAL : Method.AUTO));
        });
    }
