    {
        internal class CookieAuthenticationConfigurator : IOptionsMonitor<CookieAuthenticationOptions>
        {
            private readonly FileConfigurationBuilder ConfigProvider;
            private readonly IHostingEnvironment Environment;
            private readonly IDataProtectionProvider DataProtectionProvider;
            private readonly IMessageHub Hub;
    
            public CookieAuthenticationConfigurator(FileConfigurationBuilder configProvider, IDataProtectionProvider dataProtectionProvider, IMessageHub hub, IHostingEnvironment environment)
            {
                ConfigProvider = configProvider;
                Environment = environment;
                DataProtectionProvider = dataProtectionProvider;
                Hub = hub;
                Initialize();
            }
    
            private void Initialize()
            {
                Hub.Subscribe<ConfigurationChangeEvent>(_ =>
                {
                    Build();
                });
    
                Build();
            }
    
            private void Build()
            {
                var hostOptions = ConfigProvider.Get<HostOptions>("HostOptions");
                options = new CookieAuthenticationOptions
                {
                    ExpireTimeSpan = TimeSpan.FromHours(hostOptions.SessionLifespanHours)
                };
            }
    
            private CookieAuthenticationOptions options;
    
            public CookieAuthenticationOptions CurrentValue => options;
    
            public CookieAuthenticationOptions Get(string name)
            {
                PostConfigureCookieAuthenticationOptions op = new PostConfigureCookieAuthenticationOptions(DataProtectionProvider);
                op.PostConfigure(name, options);
                return options;
            }
    
            public IDisposable OnChange(Action<CookieAuthenticationOptions, string> listener)
            {
                throw new NotImplementedException();
            }
        }
    }
