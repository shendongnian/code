    public class RepositoriesInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Component.For<IDatabaseConnectionExecutor>()
                .ImplementedBy<FailoverDatabaseConnectionExecutor>()
                .LifestyleTransient());
    
            container.Register(Component.For<IDatabaseConnectionExecutor>()
                .ImplementedBy<DatabaseConnectionExecutor>()
                .LifestyleTransient());
    
            var configuration = container.Resolve<IConfigurationRepository>();
    
            container.Kernel.AddHandlerSelector(new DatabaseExecutorHandlerSelector(configuration));
    
            container.Release(configuration);
        }
    }
    public class DatabaseExecutorHandlerSelector : IHandlerSelector
    {
        private readonly IConfigurationRepository configurationRepository;
    
        public DatabaseExecutorHandlerSelector(IConfigurationRepository configurationRepository)
        {
            this.configurationRepository = configurationRepository;
        }
    
        public bool HasOpinionAbout(string key, Type service)
        {
            return service == typeof(IDatabaseConnectionExecutor);
        }
    
        public IHandler SelectHandler(string key, Type service, IHandler[] handlers)
        {
            var failoverEnabled = configurationRepository.GetSetting(ConfigurationSettings.BagDatabaseFailoverEnabled, () => false);
    
            var implementationToUse = failoverEnabled ? 
                typeof(FailoverDatabaseConnectionExecutor) : 
                typeof(DatabaseConnectionExecutor);
    
            return handlers.First(x => x.ComponentModel.Implementation == implementationToUse);
        }
    }
