    private static IUnityContainer container;
    protected void Application_Start() 
    {    
        container = new UnityContainer();
        ...
    }
    protected void Application_AuthenticateRequest(object sender, EventArgs e)
    {
        var service = container.Resolve<IService>();
    }
