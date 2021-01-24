    class Program
    {
        static void Main(string[] args)
        {
            // configure DI
            IServiceCollection services = ConfigureServices(new ServiceCollection());
            // build and run service host
            new IpcServiceHostBuilder(services.BuildServiceProvider())
                .AddNamedPipeEndpoint<IComputingService>(name: "endpoint1", pipeName: "pipeName")
                .AddTcpEndpoint<IComputingService>(name: "endpoint2", ipEndpoint: IPAddress.Loopback, port: 45684)
                .Build()
                .Run();
        }
        private static IServiceCollection ConfigureServices(IServiceCollection services)
        {
            return services
                .AddIpc()
                .AddNamedPipe(options =>
                {
                    options.ThreadCount = 2;
                })
                .AddService<IComputingService, ComputingService>();
        }
    }
