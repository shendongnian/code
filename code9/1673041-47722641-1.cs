    private static AppDomain MakeDomain(string name) {
        var appDomain =
            AppDomain.CreateDomain(name, AppDomain.CurrentDomain.Evidence, new AppDomainSetup {
                    ApplicationBase = AppDomain.CurrentDomain.BaseDirectory,
                    LoaderOptimization = LoaderOptimization.MultiDomainHost
                },
                new PermissionSet(PermissionState.Unrestricted));
        return appDomain;
    }
