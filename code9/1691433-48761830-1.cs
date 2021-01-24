    public class Initializer
    {
        private ServiceContainer serviceContainer;
        public static void AppInitialize()
        {
            this.serviceContainer = new ServiceContainer();
            serviceContainer.Register<ISomething, Something>();
            //etc...
        }
    }
