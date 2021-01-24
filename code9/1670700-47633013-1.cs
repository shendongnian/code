    internal static class MappingDrivers
    {
        public static void Move(Score sourceScore, string sourceType, Score targetScore, string targetType)
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Score, Score>()
                .ForMember(dest => dest.Score1, opt =>
                {
                    opt.Condition(src => string.Equals(targetType, "Driver"));
                    opt.MapFrom(src => string.Equals(sourceType, "Driver") ? src.Score1 : src.Score2);
                })
                .ForMember(dest => dest.Score2, opt =>
                {
                    opt.Condition(src => string.Equals(targetType, "CoDriver"));
                    opt.MapFrom(src => string.Equals(sourceType, "Driver") ? src.Score1 : src.Score2);
                });
            });
            Mapper.Map(sourceScore, targetScore);
        }
    }
