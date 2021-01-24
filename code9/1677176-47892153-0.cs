    public void ConfigureServices(IServiceCollection services)
    {
      services.AddMvc();
      services.AddDefaultAWSOptions(Configuration.GetAWSOptions());
      // Add service to obtain in Controllers constructor
      services.AddAWSService<IAmazonDynamoDB>();
    }
