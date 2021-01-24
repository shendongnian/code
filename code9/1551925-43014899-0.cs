    public class ModelModule : Module
    {
        public override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<Config>().As<IConfig>();
        }
    }
