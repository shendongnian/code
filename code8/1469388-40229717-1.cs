    protected void Application_Start()
    {
        ...
        ViewEngines.Engines.Add(new MyViewEngine());
    }
