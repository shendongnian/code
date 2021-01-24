    public static class MyMapper
    {
        public static Initialize()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Db.Student, Dto.StudentDto>();
            });
        }
    }
