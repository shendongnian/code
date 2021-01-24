    var container = new UnityContainer(); 
    container.LoadConfiguration(); 
    config = new HttpConfiguration(); 
    config.DependencyResolver = new UnityDependencyResolver(container);
    app.UseWebApi(config);   // Something like that
