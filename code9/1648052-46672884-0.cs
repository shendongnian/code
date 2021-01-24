    protected void Application_Start()
    {
        SetGlobalVariables();
    }
    private void SetGlobalVariables()
    {
        CompilationSection configSection = (CompilationSection)ConfigurationManager
            .GetSection("system.web/compilation");
        if (configSection?.Debug == true)
        {
            GlobalVariables.IsDebuggingEnabled = true;
        }
    }
