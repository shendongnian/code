    public class MyPlugin : IModule
    {
         public MyPlugin(MainApp.API.IMainAppInterface instance)
         {
             //do something with it.
         }
    }
    
    public class MyPluginModule: NinjectModule
    {
        protected override void Load(IKernel kernel)
        {
            kernel.Bind<MyPlugin>().To<IModule>();
        }
    }
