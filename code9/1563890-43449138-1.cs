    using System.Web.Mvc;
    using SimpleInjector;
    using SimpleInjector.Integration.Web.Mvc;
    public class Global : System.Web.HttpApplication {
    
        protected void Application_Start(object sender, EventArgs e) {
            // 1. Create a new Simple Injector container
            var container = new Container();
    
            // 2. Configure the container (register)
            // See below for more configuration examples
            container.Register<IStationController, StationController>(Lifestyle.Transient);
    
            // 3. Optionally verify the container's configuration.
            container.Verify();
    
            // 4. Store the container for use by the application
            DependencyResolver.SetResolver(
                new SimpleInjectorDependencyResolver(container));
        }
    }
