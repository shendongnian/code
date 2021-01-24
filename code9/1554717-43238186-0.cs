    public void Configure()
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<DateTime, DateTime>().ConvertUsing<UtcToLocalConverter>();
        });
        AutoMapper.Mapper.Initialize(cfg);
    }
