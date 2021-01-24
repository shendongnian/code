      Mapper.Initialize(
                cfg =>
                {
                    cfg.CreateMap<TrackedFoo, Foo>();
    
                    cfg.CreateMap<TrackedProperty<string, DateTime>, string>().ConvertUsing<TrackedPropertyConverter<string,DateTime>>();
                    cfg.CreateMap<TrackedProperty<int, DateTime>, int>().ConvertUsing<TrackedPropertyConverter<int, DateTime>>();
                    cfg.CreateMap<TrackedProperty<double, DateTime>, double>().ConvertUsing<TrackedPropertyConverter<double, DateTime>>();
                }
            );
    Mapper.AssertConfigurationIsValid();
