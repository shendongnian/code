    private void ThisAddIn_Startup(object sender, System.EventArgs e)
    {
        Csla.ApplicationContext.PropertyChangedMode = Csla.ApplicationContext.PropertyChangedModes.Windows;
        Csla.ApplicationContext.ContextManager      = new Csla.Windows.ApplicationContextManager();
        // Workaround to prevent 'SerializationException' in VSTO add-in
        // 1. Force initialisation of ConfigurationManager
        System.Configuration.ConfigurationManager.GetSection("Dummy");
        // 2. Set UnauthenticatedPrincipal explicitly after
        // setting the Csla.ApplicationContextManager
        Csla.ApplicationContext.User = new Csla.Security.UnauthenticatedPrincipal();
    }
