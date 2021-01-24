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
            appLifetime.ApplicationStarted.Register(init);
            appLifetime.ApplicationStopping.Register(stop);
        }
        private void init()
        {
            bus.Start();
        }
        private void stop()
        {
            bus.Stop();
        }
    }
