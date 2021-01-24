    public class IdentityServerConfig
        {
            public CertificateConfig CertificateConfig { get; set; }
            public DBConfig DBConfig { get; set; }
    
            public bool RaiseErrorEvents { get; set; }
            public bool RaiseFailureEvents { get; set; }
            public bool RaiseInformationEvents { get; set; }
            public bool RaiseSuccessEvents { get; set; }
        }
    public void ConfigureServices(IServiceCollection services)
    {
         ...Other Code
         var identityServerConfig = config.GetSection("IdentityServerConfig").Get<IdentityServerConfig>();
         
        var migrationsAssembly = typeof(Startup).GetTypeInfo().Assembly.GetName().Name; 
        builder = services.AddIdentityServer(options =>
                {
                    options.Events.RaiseErrorEvents = identityServerConfig.RaiseErrorEvents ;
                    options.Events.RaiseFailureEvents = identityServerConfig.RaiseFailureEvents ;
                    options.Events.RaiseInformationEvents = identityServerConfig.RaiseInformationEvents ;
                    options.Events.RaiseSuccessEvents = identityServerConfig.RaiseSuccessEvents ;
                })
   
         .AddConfigurationStore(
                         b => b.UseSqlServer(identityServerConfig.DBConfig.IdentityServer ,
                         options =>
                         {
                             options.MigrationsAssembly(migrationsAssembly);
                         }), storeOption =>
                         {
                             storeOption.DefaultSchema = identityServerConfig.DBConfig.DefaultSchema ;//IDSVR
                         })
         .AddOperationalStore(
                     b => b.UseSqlServer(identityServerConfig.DBConfig.IdentityServer,
                     options => options.MigrationsAssembly(migrationsAssembly)
                     ), storeOption => storeOption.DefaultSchema = identityServerConfig.DBConfig.DefaultSchema //IDSVR
                     );
    }
