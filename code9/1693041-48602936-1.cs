    IStringLocalizer _localizer;
    public HomeController(IStringLocalizerFactory factory)
    {
        _localizer = factory.Create("Views.Home.About", 
            System.Reflection.Assembly.GetExecutingAssembly().GetName().Name);
    }
