	public void ConfigureServices(IServiceCollection 
		services.AddEntityFrameworkNpgsql()
			.AddDbContext<SharedDbContext>(options =>
				options.UseNpgsql(Configuration["MasterConnection"]))
			.AddDbContext<DomainDbContext>((serviceProvider, options) => 
                options.UseNpgsql(Configuration["MasterConnection"])
                    .UseInternalServiceProvider(serviceProvider));
    ...
        services.Replace(ServiceDescriptor.Singleton<IModelCacheKeyFactory, MultiTenantModelCacheKeyFactory>());
		services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
