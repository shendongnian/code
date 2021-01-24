    public interface IMyApplicationContext {
        string SomeData { get; set; }
        IMyAppService SomeService { get; set; }
    }
    public interface IPlugin {
        void Do(IMyApplicationContext context)
    }
