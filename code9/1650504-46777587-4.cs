    public static class WebHostBuilderExt
    {
        public static WebHostBuilder ConfigureServicesTest(this WebHostBuilder @this, Action<IServiceCollection> configureServices)
        {
            @this.ConfigureServices(services =>
                {
                    configureServices(services);
                    services.AddMvc();
                })
                .Configure(builder =>
                {
                    builder.UseMvc();
                });
            return @this;
        }
    }
