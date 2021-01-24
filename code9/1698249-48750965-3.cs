    public class MapperProvider
    {
        private readonly Container container;
    
        public MapperProvider(Container container)
        {
            this.container = container;
        }
    
        public IMapper GetMapper()
        {
            var mce = new MapperConfigurationExpression();
            mce.ConstructServicesUsing(container.GetInstance);
    
            MapperConfiguration mc = GetMapperConfiguration(mce);
            IMapper m = new Mapper(mc, t => container.GetInstance(t));
    
            return m;
        }
    
        public static MapperConfiguration GetMapperConfiguration(MapperConfigurationExpression mce)
        {
            var profiles = typeof(ApplicationProfile).Assembly.GetTypes()
                .Where(t => typeof(Profile).IsAssignableFrom(t))
                .ToList();
    
            mce.AddProfiles(profiles);
    
            var mc = new MapperConfiguration(mce);
            mc.AssertConfigurationIsValid();
            return mc;
        }
    }
