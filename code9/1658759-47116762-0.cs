    public interface IService
    {
    }
    public interface IAnotherService
    {
    }
    public class JobService : IService
    {
        public IAnotherService m_service { get; set; }
        public JobService(IAnotherService service)
        {
            m_service = service;
        }
    }
    public class AnotherService : IAnotherService
    {
    }
	class Program
	{
		static void Main(string[] args)
		{
			IServiceCollection serviceCollection = new ServiceCollection();
			ConfigureService(serviceCollection);
			var serviceProvider = serviceCollection.BuildServiceProvider();
			//exception on next line
			var service = serviceProvider.GetService<App>();
			Console.WriteLine("Hello World!");
		}
		private static void ConfigureService(IServiceCollection serviceCollection)
		{
			serviceCollection.AddTransient<IAnotherService, AnotherService>();
			serviceCollection.AddTransient<IService, JobService>();
			serviceCollection.AddTransient<App>();
		}
	}
