    public static class MyMapper
    {
        private static bool _isInitialized;
        public static Initialize()
        {
            if (!_isInitialized)
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.CreateMap<Db.Student, Dto.StudentDto>();
                });
                _isInitialized = true;
            }
        }
    }
