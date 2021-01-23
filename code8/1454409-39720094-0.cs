    public class MapConfig
    {
        public static void RegisterMapping()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Book, BookDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name)).ReverseMap());
    
    
            AutoMapper.Mapper.Initialize(cfg => cfg.CreateMap<Book, BookDetailDTO>()
                .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name)).ReverseMap());
    
        }
    }
