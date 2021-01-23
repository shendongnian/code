    Mapper.Initialize( cfg =>
    {
       cfg.CreateMap<SerialNumber, SerialNumberModel>()
          .ForMember( dest => dest.Name, opts => opts.MapFrom(src => src.SerialNumberName));
       cfg.CreateMap<Box, BoxedElectrodesRowModel>()
          .ForMember( dest => dest.BoxId, opts => opts.MapFrom( src => src.BoxID ) )
          .ForMember( dest => dest.DateCreated, opts => opts.MapFrom( src => src.DateCreated ) );
    } );
