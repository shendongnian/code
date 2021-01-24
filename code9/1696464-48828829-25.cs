    using Container = SimpleInjector.Container;
    namespace YourNamespace
    {
        public class Bootstrapper
        {
            internal static Container Container;
        public static void Setup()
        {
            //Create container and register services
            Container = new Container();
            //Let's specify that we want to use SettingsServiceFromApplication
            Container.Register<ISettingsService, SettingsServiceFromApplication>();
            //You can use your bootstrapper class to initialize other stuff
        }
    }
