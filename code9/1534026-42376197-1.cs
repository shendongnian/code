    public HomeController(ILogger logger)
    {
        // This correctly equals MyNamespace.Controllers.HomeController.
        string controllerName = logger.Name;
    }
