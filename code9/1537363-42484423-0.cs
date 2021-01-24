    public static class UnityConfig
    {
        public static IUnityContainer container;
        public static void RegisterComponents()
        {
            container = new UnityContainer(); 
            container.RegisterType<IAccessLogBLL, AccessLogBLL>();            
            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
