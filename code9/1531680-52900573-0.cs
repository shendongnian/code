    public class DefaultModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var mapperConfiguration = new MapperConfiguration(cfg => cfg.AddProfile(new AutoMapperProfileConfiguration()));
            var mapper = mapperConfiguration.CreateMapper();
            builder.Register(c => mapper).As<IMapper>().SingleInstance();
        }
    }
