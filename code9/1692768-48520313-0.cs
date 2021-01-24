    public static MyModuleServiceCollectionExtensions
    {
        public static IServiceCollection AddMyModule(this IServiceCollection services, Action<DbContextOptionsBuilder<MyDbContext>> config
        {
            ...
            services.AddDbContext<MyDbContext>(config);
            ...
        }
    }
