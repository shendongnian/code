    public static class MySingleton
    {
        public static IInstance Instance
        {
            get;
        } = ServiceProvider.GetServiceProvider().GetService<IInstance>();
    }
