    public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var serviceScope = host.Services.CreateScope())
            {
                var services = serviceScope.ServiceProvider;
                try
                {
                    var liveDataHelper = services.GetRequiredService<ILiveDataHelper>();
                    var justInitHangfire = services.GetRequiredService<IBackgroundJobClient>();
                    //This was causing an exception (HangFire is not initialized)
                    RecurringJob.AddOrUpdate(() => liveDataHelper.RePopulateAllConfigDataAsync(), Cron.Daily());
                    // Use the context here
                }
                catch (Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "Can't start " + nameof(LiveDataHelper));
                }
            }
            host.Run();
        }
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
