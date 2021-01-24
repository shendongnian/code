    public static void MapToMeetingResolution(IMapperConfigurationExpression cfg)  
    {
       cfg.CreateMap<Table1, MyNewViewModel>()
          .ReverseMap();
          
      cfg.CreateMap<Table2, MyNewViewModel>()
         .ReverseMap();                
    }
