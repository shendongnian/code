    using Microsoft.Extensions.DependencyInjection;
    interface IMyInterface
    {
        void DoSomething();
    }
    class MyImplementation : IMyInterface
    {
        public void DoSomething()
        {
            // implementation here
        }
    }
    class Program
    {
        public static void Main()
        {
            var services = new ServiceCollection()
                .AddSingleton<IMyInterface, MyImplementation>()
                .BuildServiceProvider();
            IMyInterface impl = services.GetRequiredService<IMyInterface>();
            impl.DoSomething();
        }
    }
