    public sealed class MyModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.Register(
                c => new LuisModelAttribute("MyId", "SubId"))
                .AsSelf()
                .AsImplementedInterfaces()
                .SingleInstance();
            builder.RegisterType<MainDialog>().AsSelf().As<IDialog<object>>().InstancePerDependency();
            builder.RegisterType<LuisService>()
                .Keyed<ILuisService>(FiberModule.Key_DoNotSerialize)
                .AsImplementedInterfaces()
                .SingleInstance();
        }
    }
