     public void ConfigureServices(IServiceCollection services)
     {
        var mapperConfiguration = new MapperConfiguration(mc =>
        {
            IServiceProvider provider = services.BuildServiceProvider();
            mc.AddProfile(new AutoMapperConfiguration (provider.GetService<ICloudStorage>()));
        });
      }
