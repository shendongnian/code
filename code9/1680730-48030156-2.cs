    public static void Start()
    {
        ...
        // TODO: Uncomment if you want to use PerRequestLifetimeManager
        Microsoft.Web.Infrastructure.DynamicModuleHelper.DynamicModuleUtility.RegisterModule(typeof(UnityPerRequestHttpModule));
    }
