    configuration.CreateMap<MyMessage, MyEvent>();
    configuration.CreateMap<MyMessage, IEvent>()
        .ConstructUsing((m, c) => c.Mapper.Map<MyMessage, MyEvent>(m));
    configuration.CreateMap<MyOtherMessage, MyOtherEvent>();
    configuration.CreateMap<MyOtherMessage, IEvent>()
        .ConstructUsing((m, c) => c.Mapper.Map<MyOtherMessage, MyOtherEvent>(m));
    // etc. - will encapsulate in an extension method
