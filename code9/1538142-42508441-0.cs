    var types = _myTypeFinder.Find(type =>
        type.IsDefined(typeof(AutoMapperAttribute)) ||
        type.IsDefined(typeof(AutoMapperFromAttribute)) ||
        type.IsDefined(typeof(AutoMapperToAttribute))
        );
    
    Mapper.Initialize(cfg =>
    {
        foreach (var type in types)
        {
            AutoMapperHelper.CreateMap(type, cfg);
        }
    });
