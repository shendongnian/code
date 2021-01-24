    public class Startup
    {
        private IBus _bus;
        public void ConfigureServices(IServiceCollection services) {
            /* ... */
           
            _bus = Bus.Factory.CreateUsingRabbitMq ... 
            /* ... */
        }
        public void Configure(IApplicationLifetime appLifetime)
        {
            appLifetime.ApplicationStarted.Register(() => _bus.Start());
            appLifetime.ApplicationStopping.Register(() => _bus.Stop());
        }
    }
