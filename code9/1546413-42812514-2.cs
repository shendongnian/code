    public class AutoMapperConfig
    {
        public static void Initialize()
        {
            Mapper.Initialize((config) =>
            {
                config.CreateMap<Source, Destination>().ReverseMap();
            });
        }
    }
