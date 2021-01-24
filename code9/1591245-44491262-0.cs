 public class ControllerInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            container.Register(Classes.FromThisAssembly()
            .Pick().If(t => t.Name.EndsWith("Controller"))
            .Configure(configurer => configurer.Named(configurer.Implementation.Name))
            //.LifestylePerWebRequest()  //---this caused the bug
            .LifestyleScoped()           //the correct one
             );
        }
    }
