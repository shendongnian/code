    public class UnityConfig
    {
        public static void RegisterTypes(IUnityContainer container)
        {
            var container = new UnityContainer();
            container.AddExtension(new ApplicationExtension());
            //use container
        }
    }
