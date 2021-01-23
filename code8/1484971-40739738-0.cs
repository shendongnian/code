    public class Bootstrapper  
    {  
        public static IUnityContainer Initialize()  
        {  
            var container = BuildUnityContainer();  
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));  
            return container;  
        }  
        private static IUnityContainer BuildUnityContainer()  
        {  
            var container = new UnityContainer();  
  
            // register all your components with the container here  
            //This is the important line to edit  
            container.RegisterType<IModuleService, YourModuleService>();
            container.RegisterType<ILoggerService, YourLoggerService>();
  
            RegisterTypes(container);  
            return container;  
        }  
        public static void RegisterTypes(IUnityContainer container)  
        {  
  
        }  
    }
