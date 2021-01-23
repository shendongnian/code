      public static DestinationType CastObject<SourceType, DestinationType>(this SourceType obj)
                {
                    var config = new MapperConfiguration(cfg =>
                    cfg.CreateMap<SourceType, DestinationType>());
        
                    var mapper = config.CreateMapper();
    
                    var entity = mapper.Map<DestinationType>(obj);
        
                    return entity;
                }
