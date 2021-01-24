    CreateMap<AoACrudFieldValuesGdataHealthInput, GdataHealthTableModel>()
        .ForMember(dest => dest.PrevHealthAssessment, o => o.MapFrom(src => src.PrevHealthAssessment));
    
    CreateMap<HealthPrevHealthAssessmentEnum, GdataHealthPrevAssesmentTableModel>()
        .ForMember(dest => dest.Id, o => o.Ignore()) // auto ID
        .ForMember(dest => dest.Assessment , o => o.MapFrom(src => src));
