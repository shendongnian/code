    public static class AutomapperProfile
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<DestinationProfile>();
                cfg.AddProfile<IntermediateProfile>();
            }); 
        }
    }
