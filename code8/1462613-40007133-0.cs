    var config = new MapperConfiguration(cfg =>
    {
        cfg.CreateMap<int?, int>().ProjectUsing(x => x ?? default(int));
        cfg.CreateMap<TestClassA, TestClassA>()
            .ForMember(a => a.NullableIntPropety, o => o.MapFrom(a => a.NullableIntProperty));
    }
