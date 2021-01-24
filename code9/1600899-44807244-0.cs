       protected void Application_Start()
        {       
            AreaRegistration.RegisterAllAreas();
    
           //Here is the entry
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
    
            ModelBinders.Binders.DefaultBinder = new DevExpress.Web.Mvc.DevExpressEditorsBinder();
        }
