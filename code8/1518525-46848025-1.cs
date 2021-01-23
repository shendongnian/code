        public class AndroidInitializer : IPlatformInitializer
    {
        public void RegisterTypes(IContainer container)
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule<ExampleModule>();
            builder.Update(container);
        }
    }
