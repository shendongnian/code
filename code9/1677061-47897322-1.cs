    internal static class WebIoC
    {
        public static IContainer BuildContainer()
        {
            var lifetimeScopeTag = MatchingScopeLifetimeTags.RequestLifetimeScopeTag;
            var builder = new ContainerBuilder();
            builder.RegisterModule(new MyModule(lifetimeScopeTag));
    
            return builder.Build();
        }
    }
