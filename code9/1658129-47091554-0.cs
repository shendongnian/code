    protected void Application_Start()
    {
        Bootstrap();
        //and do something more
    }
    private static void Bootstrap()
    {
        var container = new Container();
        container.Register(() => new HttpClient());
        container.RegisterSingleton<IApiCaller, ApiCaller>();
        container.RegisterInitializer<IApiCaller>(ApiCaller=> apicaller.StartCallingAsync());
        // Suppress warnings for HttpClient
        var registration = container.GetRegistration(typeof(HttpClient)).Registration;
        registration.SuppressDiagnosticWarning(DiagnosticType.DisposableTransientComponent, "Dispose is being called by code.");
        registration.SuppressDiagnosticWarning(DiagnosticType.LifestyleMismatch, "Every HttpCient is unique for each dependency.");
        container.Verify();
        GlobalConfiguration.Configuration.DependencyResolver = new SimpleInjectorWebApiDependencyResolver(container);
    }
