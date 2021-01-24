    protected void Application_Start()
    {
        AreaRegistration.RegisterAllAreas();
        RouteConfig.RegisterRoutes(RouteTable.Routes);
        ModelBinders.Binders.DefaultBinder = new CustomModelBinder();
    }
