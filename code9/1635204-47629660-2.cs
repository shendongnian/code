    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc();
        services.AddSingleton<IActionDescriptorChangeProvider>(MyActionDescriptorChangeProvider.Instance);
        services.AddSingleton(MyActionDescriptorChangeProvider.Instance);
    }
