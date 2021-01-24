    [DependsOn(typeof(PortalCoreModule),typeof(PortalEntityFrameworkModule), typeof(PortalApplicationModule),typeof(AbpHangfireModule), typeof(AbpZeroCoreModule), typeof(AbpAutoMapperModule))]
    public class PortalServiceModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(PortalServiceModule).GetAssembly());
    
            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.CreateMap<object, int?>().ConvertUsing<NullableIntTypeConverter>();
    
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg.AddProfiles(typeof(PortalApplicationModule).GetAssembly());
            });
    
            Configuration.BackgroundJobs.UseHangfire(config =>
            {
                config.GlobalConfiguration.UseSqlServerStorage(PortalConsts.ConnectionStringName, new SqlServerStorageOptions
                {
                    PrepareSchemaIfNecessary = true
                });
    
                config.Server = new BackgroundJobServer(new BackgroundJobServerOptions
                {
                    Queues = new[] { BackgroundJobQueueNames.Critical, BackgroundJobQueueNames.Autotask, BackgroundJobQueueNames.Default }
                });
    
                config.GlobalConfiguration.UseConsole();
            });
    
            GlobalJobFilters.Filters.Add(new DisableMultipleQueuedItemsFilter());
        }
    
        public override void PostInitialize()
        {
            HangfireJobsConfigurer.Configure();
        }
    }
