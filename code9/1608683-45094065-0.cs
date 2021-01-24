    public class AutoMapperProfileConfiguration : Profile
    {
        public AutoMapperProfileConfiguration()
            : this("MyProfile")
        {
        }
    
        protected AutoMapperProfileConfiguration(string profileName)
            : base(profileName)
        {
            CreateMap<Source, Dest>()
                .ForMember(dest => dest.Schedule, opt =>
                {
                    opt.MapFrom(src => new Schedule((ScheduleBaseEnum)src.ScheduleBaseId, src.ScheduleIncrement));
                })
                .ForMember(dest => dest.SubscriptionCriteria, opt =>
                {
                    opt.MapFrom(src => (ISubscriptionCriteria)JsonConvert.DeserializeObject(src.SubscriptionCriteriaJson, GetSubscriptionCriteriaType((SubscriptionTypeEnum)src.SubscriptionTypeId)));
                });
        }
    
        private Type GetSubscriptionCriteriaType(SubscriptionTypeEnum type)
        {
            switch (type)
            {
                case SubscriptionTypeEnum.SomeType1:
                    return typeof(SomeType1);
                case SubscriptionTypeEnum.SomeType2:
                    return typeof(SomeType2);
                ...
                default:
                    throw new NotImplementedException(string.Format("SubscriptionType of {0} is not implemented.", Enum.GetName(typeof(SubscriptionTypeEnum), type)));
            }
        }
    }
