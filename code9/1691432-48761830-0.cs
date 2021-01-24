    public class Startup
    {
        private ServiceContainer serviceContainer;
        public static void Initialize()
        {
            this.serviceContainer = new ServiceContainer();
            serviceContainer.Register<ISomething, Something>();
            //etc...
        }
    }
