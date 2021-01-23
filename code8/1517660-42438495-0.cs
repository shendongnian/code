    public class MyBLL
    {
        private static IMapper _mapper;
        static MyBLL()
        {
            _mapper = MapperFactory.CreateMapper<DtoToEntityDefaultProfile>();
        }
    }
    public static class MapperFactory
    {
        public static IMapper CreateMapper<T>() where T : Profile, new()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<T>();
            });
            /// AssertConfigurationIsValid will detect 
            /// all unmapped properties including f.e Navigation properties, Nested DTO classes etc.
            config.AssertConfigurationIsValid();
            config.CompileMappings();
            return config.CreateMapper();
        }
    }
