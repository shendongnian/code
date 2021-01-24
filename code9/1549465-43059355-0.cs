    public static void RegisterTypes(IUnityContainer container) {
        // Register the default type in code
        container.RegisterType<IToolbarLogic, ToolbarLogic>();
        // Override with the config file, if there is a unity section.
        if (ConfigurationManager.GetSection("unity") != null) {
            // There is an Unity.config file
            container.LoadConfiguration();
        }        
    }
