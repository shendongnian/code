    static void Main(string[] args) {
        var services = new ServiceCollection();
        var moduleInitializer = new ModuleInitializer();
        moduleInitializer.Init(services);
        IServiceProvider serviceProvider = services.BuildServiceProvider();
    
        //Get String Values each module and show on console ..
        var collectors = serviceProvider.GetServices<ICollector>();
        foreach(ICollector collector in collectors) {
            Console.WriteLine(collector.CollectSomething());
        }
    }
