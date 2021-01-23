    public virtual void ApplyServices(IServiceCollection services)
    {
        Check.NotNull(services, nameof(services));
        services.AddEntityFrameworkInMemoryDatabase();
    }
