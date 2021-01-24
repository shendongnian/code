    public class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<source,destination>(); /*If source and destination object have same propery */
                cfg.CreateMap<source, destination>()
                 .ForMember(dest => dest.dId, opt => opt.MapFrom(src => src.sId)); /*If source and destination object haven't same property, you need do define which property refers to source property */ 
             });
        }
    }
