    public static class Injector
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IUserDataService, UserDataService>();
        }
    }
