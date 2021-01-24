    public class Program
    {
        static void Main()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<MyMessageHandler>().As<IMessageHandler>();
            builder.RegisterType<Functions>()
                .InstancePerDependency();
            var host = new JobHost(new JobHostConfiguration
            {
                JobActivator = new AutofacJobActivator(builder.Build())
            });
            host.RunAndBlock();
        }
    }
    public class AutofacJobActivator : IJobActivator
    {
        private readonly IContainer _container;
        public AutofacJobActivator(IContainer container)
        {
            _container = container;
        }
        public T CreateInstance<T>()
        {
            return _container.Resolve<T>();
        }
    }
    public class Functions
    {
        private IMessageHandler _myService;
        //You can use Dependency Injection if you want to. 
        public Functions(IMessageHandler myService)
        {
            _myService = myService;
        }
        // This function will get triggered/executed when a new message is written 
        // on an Azure Queue called queue.
        public async Task ProcessQueueMessage1(
            [QueueTrigger("test1")] CloudQueueMessage message,
            IBinder binder)
        {
            _myService.HandleMessage(message.AsString);
            Console.WriteLine("ProcessQueueMessage1 was run");
            await Task.CompletedTask;
        }
        public async Task ProcessQueueMessage2(
            [QueueTrigger("test2")] CloudQueueMessage message,
            IBinder binder)
        {
            _myService.HandleMessage(message.AsString);
            Console.WriteLine("ProcessQueueMessage2 was run");
            await Task.CompletedTask;
        }
    }
