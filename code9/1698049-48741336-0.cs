    // lifetime will be injected to Configure from DI container
    public void Configure(IApplicationBuilder app, IApplicationLifetime lifetime) {
        // subscribe to ApplicationStopped
        lifetime.ApplicationStopped.Register(OnApplicationStopped);
        // the rest
    }
    private void OnApplicationStopped() {
        _bus.Stop();
    }
