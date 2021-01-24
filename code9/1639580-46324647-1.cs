    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            AutoMapper.Mapper.CreateMap<ModelFoo, ViewModelFoo>()
                .ForMember(dest => dest.Author,
                           opts => opts.MapFrom(src => src.Author.Name));
        }
    }
