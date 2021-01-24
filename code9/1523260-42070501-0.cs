    [InitializableModule]
    [ModuleDependency((typeof(EPiServer.Web.InitializationModule)))]
    public class MyInitializationModule : IInitializableModule
    {
        public void Initialize(InitializationEngine context)
        {
           // Your code here
        }
        public void Uninitialize(InitializationEngine context)
        {
        }
    }
