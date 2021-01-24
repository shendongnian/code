    public void ConfigureServices(IServiceCollection services)
    {
        services.AddTransientFromService<OptionsReader, MyOptions>(reader => reader.GetOptions());
    }
    //...
    public static void AddTransientFromService<TReader, TOptions>(
        this IServiceCollection services,
        Func<TReader, TOptions> getOptions)
        where TReader : class
        where TOptions : class
    {
        services.AddTransient(provider => getOptions(provider.GetService<TReader>()));
    }
