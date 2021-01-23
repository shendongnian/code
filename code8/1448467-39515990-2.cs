    public Dog UsingAMR(Person prs)
    {
        var config = new MapperConfiguration(cfg =>
        {
            cfg.CreateMap<Person, Dog>();
        });
        IMapper mapper = config.CreateMapper();
        return mapper.Map<Person, Dog>(prs);
    }
