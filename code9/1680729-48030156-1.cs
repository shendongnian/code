    public static void Start()
    {
        // Use UnityHierarchicalDependencyResolver if you want to use
        // a new child container for each IHttpController resolution.
        var resolver = new UnityHierarchicalDependencyResolver(UnityConfig.Container);
        ...
    }
    
