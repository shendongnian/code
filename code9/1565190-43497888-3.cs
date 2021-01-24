    public static class AutoMapperConfig
    {
        public static void RegisterMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.RecognizeDestinationPrefixes(new []{"ud_"});
                cfg.RecognizePrefixes(new[] { "ud_" });
                cfg.DestinationMemberNamingConvention = new LowerUnderscoreNamingConvention();
                cfg.SourceMemberNamingConvention = new PascalCaseNamingConvention();
                cfg.CreateMap<User, user_dto>().ReverseMap().AfterMap((src, dest) => dest.FirstName = src.ud_first_name);
                cfg.CreateMap<user_dto, User>().ReverseMap().AfterMap((src, dest) => dest.ud_first_name = src.FirstName);
            });
        }
    }
