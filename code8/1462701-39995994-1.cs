    public class MyPluginModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register<ImportCustomers>().As<IImportPlugin>();
        }
    }
