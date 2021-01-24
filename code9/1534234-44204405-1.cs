    class Helper
    {
        public static MapperConfiguration InitializeAutoMapper()
        {
            MapperConfiguration config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new ProfileA());
                cfg.AddProfile(new ProfileB());
            });
            return config;
        }
    }
