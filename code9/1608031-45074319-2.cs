    public static class WithLifetime
    {
        public static LifetimeManager FromMarkerInterface(Type type)
        {
            if (typeof(ISingletonDependency).IsAssignableFrom(type))
            {
                return new ContainerControlledLifetimeManager();
            }
            return new TransientLifetimeManager();
        }
    }
