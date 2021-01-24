    public interface IMyReusableViewModel { }
    public class MyReusableViewModel1 : IMyReusableViewModel { }
    public class MyReusableViewModel2 : IMyReusableViewModel { }
    IServiceCollection collection = new ServiceCollection();
    collection.AddSingleton<IMyReusableViewModel, MyReusableViewModel1>("View1");
    collection.AddSingleton<IMyReusableViewModel, MyReusableViewModel2>("View2");
    public class MyService
    {
        private readonly IServiceProvider provider;
        public MyService(IServiceProvider provider)
        {
            this.provider = provider;
        }
        public void DoSomething()
        {
            var view1 = provider.GetService<IMyReusableViewModel>("View1");
            var view2 = provider.GetService<IMyReusableViewModel>("View2");
            // ...
        }
    }
    
