    internal static class JobRunnerIoC
    {    
        public const string LifetimeScopeTag = "I_Love_Lamp";
    
        public static IContainer BuildContainer()
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new MyModule(LifetimeScopeTag));
    
            // Don't forget to register your jobs!
            builder.RegisterType<SomeJob>().AsSelf().As<IJob>();
            builder.RegisterType<SomeOtherJob>().AsSelf().As<IJob>();
    
            return builder.Build();
        }
    }
