    namespace MyProject.Domain.Mapping
    {
        public enum Status
        {
            Unknown,
            Example,
            AnotherExample,
            PossibleExample
        }
    
        public class RecordPost
        {
            public Status Status { get; set; }
        }
    
        public class RecordDto
        {
            public string Status { get; set; }
        }
    
        public static class AutoMapperConfiguration
        {
            public static void Configure()
            {
                Mapper.Initialize(cfg =>
                {
                    cfg.AddProfile(new RecordProfile());
                });
    
                Mapper.AssertConfigurationIsValid();
            }
        }
    
        public class RecordProfile : Profile
        {
            public RecordProfile()
            {
                CreateMap<RecordPost, RecordDto>()
                    .ForMember(x => x.Status, opt => opt.MapFrom(src => src.Status.ToString()));
    
                CreateMap<RecordDto, RecordPost>()
                    .ForMember(x => x.Status, opt => opt.ResolveUsing(src =>
                    {
                        if (!Enum.TryParse(typeof(Status), src.Status, out var parsedResult))
                            return Status.Unknown;
                        return parsedResult;
                    }));
            }
        }
    }
