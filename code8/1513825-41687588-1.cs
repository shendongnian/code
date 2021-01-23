    public static class AutoMapperConfiguration
    {
        public static void Initialize()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SKU, SKUViewModel>();
                cfg.CreateMap<SKUViewModel, SKU>();
                cfg.CreateMap<Lot, LotViewModel>();
                cfg.CreateMap<LotViewModel, Lot>();
            });
            Mapper = MapperConfiguration.CreateMapper();
        }
    
        public static IMapper Mapper { get; private set; }
    
        public static MapperConfiguration MapperConfiguration { get; private set; }
    }
