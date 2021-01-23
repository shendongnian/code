        public void ConfigureServices(IServiceCollection services) {
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSingleton<ISingletonService, SingletonService>();
            services.AddScoped<IScopedService, ScopedService>();
            services.AddTransient<IProvider<IScopedService>, Provider<IScopedService>>();
            // other bindings
        }
:)
