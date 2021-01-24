    Mapper.Initialize(
        cfg =>
        {
            cfg.CreateMap<Foo, TrackedFoo>();
            cfg.CreateMap<string, TrackedProperty<string,DateTime>>().ConvertUsing<StringTrackedPropertyConverter>();
        }
    );
    Mapper.AssertConfigurationIsValid();
