    public class OurServiceHostFactory : SimpleInjectorServiceHostFactory
    {
        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
			// ConfigInit is a static class with a simple check, to see if the configuration was already initialized
			// the same method ConfigInig.Configure() is also called in the Global.asax in Application_Start
            ConfigInit.Configure();
            return base.CreateServiceHost(serviceType, baseAddresses);
        }
    }
