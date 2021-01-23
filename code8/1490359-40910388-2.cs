    using AutoMapper;
    
    public class MyAutoMapperProfile : Profile {
        
        protected override void Configure() {
            CreateMap<User, SMUser>();
            CreateMap<SurveyMonkey.Containers.Survey, Survey>();
            CreateMap<List<SurveyMonkey.Containers.Collector>, List<Collector>>();
        }
    }
