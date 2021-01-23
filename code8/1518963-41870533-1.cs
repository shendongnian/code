    public abstract class MapperBase<TIn, TOut, TProfile> : IMapper<TIn, TOut> where TProfile : Profile, new()
    {
        internal IConfigurationProvider MapperConfiguration { get; set; }
        protected MapperBase()
        {
            MapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<TProfile>();
            });
        }
        public TOut Map(TIn objectToMap)
        {
            return MapperConfiguration.CreateMapper().Map<TOut>(objectToMap);
        }
    }
