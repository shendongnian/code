    config.CreateMap<AskQuestionViewModel, Question>()
           .ForMember(dest => dest.Deputy, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src))
           .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Name))
           .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Eamil))
           .ForMember(dest => dest.Tel, opt => opt.MapFrom(src => src.PhoneNumber))
           .ForMember(dest => dest.Municipality, opt => opt.MapFrom(src => src))
           ;
    config.CreateMap<AskQuestionViewModel, Deputy>()
           .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.DeputyId));
    config.CreateMap<AskQuestionViewModel, Municipality>()
           .ForMember(dest => dest.ID, opt => opt.MapFrom(src => src.MunicipalityId));
    config.CreateMap<AskQuestionViewModel, Text>()
           .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Question));
