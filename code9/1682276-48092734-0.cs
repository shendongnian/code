    if (implementedList.Any())
    {
        services.AddMvc()
            .AddApplicationPart(assembly)
            .AddControllersAsServices();
    
        foreach(var type in implementedList)
        {
             var module = Activator.CreateInstance(type) as IModule;
             var properties = module.GetProperties();
             var views = module. GetViews();
             //make use of the properties and views...
        }
    }
