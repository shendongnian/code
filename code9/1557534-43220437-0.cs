    Mapper.CreateMap<Task, DTO.Task>()
      .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src.ToList<Attachment>())
      .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src.ToList<Comment>())
      .ReverseMap()
        .ForMember(dest => dest.Attachments, opt => opt.MapFrom(src => src as ICollection<Attachment>)
        .ForMember(dest => dest.Comments, opt => opt.MapFrom(src => src as ICollection<Comment>);
