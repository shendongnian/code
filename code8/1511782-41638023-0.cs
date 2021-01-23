    Mapper.Initialize(cfg =>
    {
        cfg.CreateMap<List<string>, MyCollection>().ConvertUsing(s => new MyCollection(s));
        cfg.CreateMap<SourceItem, DestItem>();
    });
