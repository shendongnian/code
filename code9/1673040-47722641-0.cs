    private static AppDomain MakeDomain(string name, string toolPath)
    {
        var appDomain =
            AppDomain.CreateDomain(name, AppDomain.CurrentDomain.Evidence, new AppDomainSetup
                {
                    ApplicationBase = toolPath,                        
                    LoaderOptimization = LoaderOptimization.MultiDomainHost
                },
                new PermissionSet(PermissionState.Unrestricted));
        return appDomain;
    }
