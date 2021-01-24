    public class AppBootstrapper : BootstrapperBase
    {
        public AppBootstrapper()
        {
            Initialize();
        }
    
        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<TestViewModel>();
        }
    }
