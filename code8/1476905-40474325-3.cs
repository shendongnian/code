    protected void Application_Start()
    {
        ViewEngines.Engines.Clear();
        ExtendedRazorViewEngine engine = new ExtendedRazorViewEngine();
        ViewEngines.Engines.Add(engine);
        ...
    }
