    public MapperConfiguration Configure()
    {
        AutoMapper.Mapper.Initialize(cfg =>
        {
            cfg.AddProfile<ViewModelToDomainMappingProfile>();
            cfg.AddProfile<DomainToViewModelMappingProfile>();
            cfg.AddProfile<BiDirectionalViewModelDomain>();
        });
    }
