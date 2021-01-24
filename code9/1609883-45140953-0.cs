        [Export(typeof(IService))] // Add this export
        public class Plugin1Service : IService
        {
            [Import(typeof(Ilog))]
            public Ilog Log { get; private set; }//todo:Log is null
            public void DoSomeThing()
            {
                Log.Log("test from Plugin1");
            }
        }
        [Export(typeof(IPlugin))]
        public class Plugin1Info : IPlugin
        {
            public string PluginName => "Plugin1";
            [Import] // Import the service
            public IService Service { get; set; }
        }
