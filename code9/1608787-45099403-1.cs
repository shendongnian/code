    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        // clear all view engines repository first
        ViewEngines.Engines.Clear();
        // register Razor view engine only
        ViewEngines.Engines.Add(new RazorViewEngine());
        // register custom view engine class here
        ViewEngines.Engines.Add(new CustomViewEngine());
        // other initialization codes here
    }
