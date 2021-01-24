    protected void Application_Start()
    {
        TelemetryConfiguration.Active.TelemetryInitializers
            .Add(new UserTelemetryIntitializer());
    }
