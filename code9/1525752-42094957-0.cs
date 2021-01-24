    Mapper.Initialize(cfg => cfg.CreateMap<dynamic, testclass>()
                .ForMember(dest => dest.letter, opt => opt.ResolveUsing(src => src.Name))
                .ForMember(dest => dest.frequency, opt => opt.ResolveUsing(src => src.Age)));
    // Use the mapping
    foreach (testclass a in Mapper.Map<List<testclass>>(getlist()))
    {
        Console.WriteLine(a.letter);
    }
    Console.ReadKey();
