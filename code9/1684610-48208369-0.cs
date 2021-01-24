    public void ConfigureServices(IServiceCollection services)
    {
        // …
        // register our observer
        services.AddSingleton<DiagnosticObserver>();
    }
    public void Configure(IApplicationBuilder app, IHostingEnvironment env,
        // we inject both the DiagnosticListener and our DiagnosticObserver here
        DiagnosticListener diagnosticListenerSource, DiagnosticObserver diagnosticObserver)
    {
        // subscribe to the listener
        diagnosticListenerSource.Subscribe(diagnosticObserver);
        // …
    }
