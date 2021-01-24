        Hangfire.GlobalConfiguration.Configuration.UseActivator(new ContainerJobActivator(container));
        Hangfire.GlobalConfiguration.Configuration.UseSqlServerStorage(ConfigurationManager.ConnectionStrings[ConfigurationKeys.DbDefaultConnectionName].ConnectionString);
        app.UseHangfireDashboard();
        app.UseHangfireServer();
    
  
     public class ContainerJobActivator : JobActivator
        {
            private IUnityContainer _container;
    
            public ContainerJobActivator(UnityContainer container)
            {
                _container = container;
            }
    
            public override object ActivateJob(Type type)
            {
                return _container.Resolve(type);
            }
        }
