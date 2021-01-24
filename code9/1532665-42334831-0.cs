    class MyRegistry : Registry
    {
        public MyRegistry()
        {
            For<MapperConfiguration>()
                .Use("Use StructureMap context to resolve AutoMapper services", ctx =>
                {
                    return new MapperConfiguration(config =>
                    {
                        config.ConstructServicesUsing(type => ctx.GetInstance(type));
                    });
                });
        }
    }
