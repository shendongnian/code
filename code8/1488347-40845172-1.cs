    Mapper.Initialize(cfg =>
    {
         cfg.ShouldMapProperty = p => p.GetMethod.IsPublic || p.GetMethod.IsAssembly;
         cfg.CreateMap<Source, Destination>();
    });
