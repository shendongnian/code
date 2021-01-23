    public static class MySingleton
    {
        public static IInstance Instance
            => ServiceProvider.GetServiceProvider().GetService<IInstance>();
    }
