          public static class DataConversionsExtensions
        {
            private static readonly IMapper Mapper;
    
            static DataConversionsExtensions()
            {
                var configuration = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<Field, DbField>();
                    cfg.CreateMap<DbField, Field>();  });
    
                Mapper = new Mapper(configuration);
            }
            public static Field ToField(this DbField field)
            {
                return Mapper.Map<Field>(field);
            }
    
            public static DbField ToDbField(this Field field)
            {
                return Mapper.Map<DbField>(field);
            }
    }
