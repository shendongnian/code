    public void ConfigureServices(IServiceCollection services)
    {
        services.AddMvc(options =>
        {
            options.Filters.Add(new ProducesAttribute("application/json"));
        });
    }
