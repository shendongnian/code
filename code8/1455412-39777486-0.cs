    public static class WindsorExtentions
    {
        public static T Construct<T>(this IWindsorContainer container)
            where T : class
        {
            if (!container.Kernel.HasComponent(typeof(T)))
                container.Register(Component.For<T>());
    
            var instance = container.Resolve<T>();
            return instance;
        }
    }
