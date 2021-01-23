    public Dog UsingAMR(Person mdt)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Person, Dog >();
        });
        IMapper mapper = config.CreateMapper();
        return mapper.Map<Person, Dog >(mdt);
    }
