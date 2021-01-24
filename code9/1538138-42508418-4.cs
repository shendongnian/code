    public static class MappingDTOModelToModel
    {       
         private static void Configure()
         {
             Mapper.Initialize(cfg =>
             {
                 cfg.CreateMap<R_Logo, LogoDto>()
                     .ForMember(x => x.ID,
                                m => m.MapFrom(a => a.ID))
                     .ForMember(x => x.FirstName,
                                m => m.MapFrom(a => a.FirstName)).ReverseMap();                    
             }
         }
     }
