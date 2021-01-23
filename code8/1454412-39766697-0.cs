          AutoMapper.Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Book, BookDTO>()
                    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
                cfg.CreateMap<Book, BookDetailDTO>()
                 .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author.Name));
            });
