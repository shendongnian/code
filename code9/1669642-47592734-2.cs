    public class PortalService : ServiceControl
    {
        public const string ServiceName = "PortalWorker";
        public const string ServiceDisplayName = "Portal Worker";
        public const string ServiceDescription = "Process the background jobs for the Portal.";
    
        private AbpBootstrapper _bootstrapper;
        public bool Start(HostControl hostControl)
        {
    
            _bootstrapper = AbpBootstrapper.Create<PortalServiceModule>();
    
            _bootstrapper.Initialize();
    
            return true;
        }
    
        public bool Stop(HostControl hostControl)
        {
            _bootstrapper.Dispose();
            return true;
        }
    }
