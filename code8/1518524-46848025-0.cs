        public  class ExampleModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<LoginP>().As<ILoginP>().InstancePerDependency();
            base.Load(builder);
        }
    }
