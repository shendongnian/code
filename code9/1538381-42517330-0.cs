    public static class AutoMaps
    {
        public static void Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                CreateGenericMapping<CatModel>(cfg);
            });
        }
        public static void CreateCatMapping<TCatType>(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TCatType, Cat>();
            cfg.CreateMap<Cat, TCatType>();
        }
    }
